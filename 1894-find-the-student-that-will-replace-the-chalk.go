package main

import "sort"

func chalkReplacer(chalk []int, k int) int {
	n := len(chalk)
	prefix := make([]int, n)

	prefix[0] = chalk[0]
	for i := 1; i < n; i++ {
		prefix[i] = chalk[i] + prefix[i-1]
	}

	k %= prefix[n-1]
	return sort.SearchInts(prefix, k+1)
}
