package main

func countDigits(n int) [10]int {
	cnt := [10]int{}
	for n > 0 {
		cnt[n%10]++
		n /= 10
	}
	return cnt
}

var mp = map[[10]int]bool{}

func init() {
	for n := 1; n <= 1e9; n <<= 1 {
		mp[countDigits(n)] = true
	}
}

func reorderedPowerOf2(n int) bool {
	return mp[countDigits(n)]
}
