package main

func countNegatives(grid [][]int) int {
	res, m, pos := 0, len(grid[0]), len(grid[0])-1
	for _, row := range grid {
		i := 0
		for i = pos; i >= 0; i-- {
			if row[i] >= 0 {
				if i+1 < m {
					pos = i + 1
					res += m - pos
				}
				break
			}
		}
		if i == -1 {
			res += m
			pos = -1
		}
	}
	return res
}
