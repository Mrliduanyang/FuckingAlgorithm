package main

func max(x, y int) int {
	if x > y {
		return x
	}
	return y
}
func getMaximumGenerated(n int) int {
	if n == 0 {
		return 0
	}
	nums := make([]int, n+1)
	nums[1] = 1
	for i := 2; i <= n; i++ {
		nums[i] = nums[i/2] + i%2*nums[i/2+1]
	}
	ans := -1
	for _, num := range nums {
		ans = max(ans, num)
	}
	return ans
}
