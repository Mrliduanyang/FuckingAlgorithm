package main

const mod int = 1e9 + 7

var dirs = []struct{ x, y int }{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}

func findPaths(m int, n int, maxMove int, startRow int, startColumn int) int {
	dp := make([][][]int, maxMove+1)
	for k := range dp {
		dp[k] = make([][]int, m)
		for i := range dp[k] {
			dp[k][i] = make([]int, n)
		}
	}

	dp[0][startRow][startColumn] = 1
	res := 0
	for k := 0; k < maxMove; k++ {
		for i := 0; i < m; i++ {
			for j := 0; j < n; j++ {
				count := dp[k][i][j]
				if count > 0 {
					for _, dir := range dirs {
						x, y := i+dir.x, j+dir.y
						if x >= 0 && x < m && y >= 0 && y < n {
							dp[k+1][x][y] = (dp[k+1][x][y] + count) % mod
						} else {
							res = (res + count) % mod
						}
					}
				}
			}
		}
	}
	return res
}
