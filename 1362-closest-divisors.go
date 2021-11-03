package main

import "math"

func divide(n int) []int {
	for i := int(math.Sqrt(float64(n))); i >= 0; i-- {
		if n%i == 0 {
			return []int{i, n / i}
		}
	}
	return []int{}
}

func abs(n int) int {
	if n < 0 {
		return -n
	}
	return n
}

func closestDivisors(num int) []int {
	res := []int{0, 1e9}
	for i := num + 1; i <= num+2; i++ {
		cur := divide(i)
		if abs(cur[0]-cur[1]) < abs(res[0]-res[1]) {
			res = cur
		}
	}
	return res
}
