package main

func shoppingOffers(price []int, special [][]int, needs []int) int {
	n := len(price)

	// 过滤不需要计算的大礼包，只保留需要计算的大礼包
	filterSpecial := [][]int{}
	for _, s := range special {
		totalCount, totalPrice := 0, 0
		for i, c := range s[:n] {
			totalCount += c
			totalPrice += c * price[i]
		}
		if totalCount > 0 && totalPrice > s[n] {
			filterSpecial = append(filterSpecial, s)
		}
	}

	dp := map[string]int{}
	var helper func([]byte) int
	helper = func(curNeeds []byte) (minPrice int) {
		if res, has := dp[string(curNeeds)]; has {
			return res
		}
		for i, p := range price {
			minPrice += int(curNeeds[i]) * p
		}
		nextNeeds := make([]byte, n)
	outer:
		for _, s := range filterSpecial {
			for i, need := range curNeeds {
				if need < byte(s[i]) {
					continue outer
				}
				nextNeeds[i] = need - byte(s[i])
			}
			minPrice = min(minPrice, helper(nextNeeds)+s[n])
		}
		dp[string(curNeeds)] = minPrice
		return
	}

	curNeeds := make([]byte, n)
	for i, need := range needs {
		curNeeds[i] = byte(need)
	}
	return helper(curNeeds)
}

func min(a, b int) int {
	if a > b {
		return b
	}
	return a
}
