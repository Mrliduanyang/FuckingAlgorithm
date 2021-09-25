package main

func minDistance(word1, word2 string) int {
	m, n := len(word1), len(word2)
	dp := make([][]int, m+1)
	for i := range dp {
		dp[i] = make([]int, n+1)
		dp[i][0] = i
	}
	for j := range dp[0] {
		dp[0][j] = j
	}
	for i, ch1 := range word1 {
		for j, ch2 := range word2 {
			if ch1 == ch2 {
				dp[i+1][j+1] = dp[i][j]
			} else {
				dp[i+1][j+1] = min(dp[i][j+1], dp[i+1][j]) + 1
			}
		}
	}
	return dp[m][n]
}
func min(x, y int) int {
	if x > y {
		return y
	}
	return x
}
