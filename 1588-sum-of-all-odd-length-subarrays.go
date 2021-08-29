package main

func sumOddLengthSubarrays(arr []int) int {
	n := len(arr)
	preSum := make([]int, n+1)

	for i := 0; i < n; i++ {
		preSum[i+1] = preSum[i] + arr[i]
	}

	res := 0
	for start := 0; start < n; start++ {
		for length := 1; start+length <= n; length += 2 {
			end := start + length - 1
			res += preSum[end+1] - preSum[start]
		}
	}

	return res
}
