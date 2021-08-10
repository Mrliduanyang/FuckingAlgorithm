package main

func numberOfArithmeticSlices(nums []int) int {
	n := len(nums)
	res := 0
	for i := 0; i < n-2; {
		j := i
		diff := nums[i+1] - nums[i]
		for ; j+1 < n && nums[j+1]-nums[j] == diff; j++ {
		}
		length := j - i + 1
		a1 := 1
		an := length - 2
		res += (a1 + an) * an / 2
		i = j
	}
	return res
}
