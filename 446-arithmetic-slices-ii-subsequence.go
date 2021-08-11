package main

func numberOfArithmeticSlices(nums []int) int {
	res := 0
	dp := make([]map[int]int, len(nums))
	for i, x := range nums {
		dp[i] = map[int]int{}
		for j, y := range nums[:i] {
			diff := x - y
			count := dp[j][diff]
			res += count
			dp[i][diff] += count + 1
		}
	}
	return res
}
