package main

func majorityElement(nums []int) []int {
	element1, element2 := 0, 0
	vote1, vote2 := 0, 0

	for _, num := range nums {
		if vote1 > 0 && num == element1 {
			vote1++
		} else if vote2 > 0 && num == element2 {
			vote2++
		} else if vote1 == 0 {
			element1 = num
			vote1++
		} else if vote2 == 0 {
			element2 = num
			vote2++
		} else {
			vote1--
			vote2--
		}
	}

	cnt1, cnt2 := 0, 0
	for _, num := range nums {
		if vote1 > 0 && element1 == num {
			cnt1++
		}
		if vote2 > 0 && element2 == num {
			cnt2++
		}
	}
	ret := []int{}
	if vote1 > 0 && cnt1 > len(nums)/3 {
		ret = append(ret, element1)
	}

	if vote2 > 0 && cnt2 > len(nums)/3 {
		ret = append(ret, element2)
	}
	return ret
}
