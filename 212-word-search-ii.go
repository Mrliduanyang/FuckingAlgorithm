package main

func findWords(board [][]byte, words []string) []string {
	m, n := len(board), len(board[0])
	dirs := []struct{ x, y int }{{-1, 0}, {1, 0}, {0, -1}, {0, 1}}
	vis := make([][]bool, m)
	for i := range vis {
		vis[i] = make([]bool, n)
	}
	var exist func(i, j int, word string) bool
	exist = func(i, j int, word string) bool {
		var helper func(i, j, idx int) bool
		helper = func(i, j, idx int) bool {
			if board[i][j] != word[idx] {
				return false
			} else if idx == len(word)-1 {
				return true
			}

			// 回溯
			vis[i][j] = true
			res := false

			for _, dir := range dirs {
				tx, ty := i+dir.x, j+dir.y
				if tx >= 0 && tx < m && ty >= 0 && ty < n {
					if !vis[tx][ty] {
						flag := helper(tx, ty, idx+1)
						if flag {
							res = true
							break
						}
					}
				}
			}

			vis[i][j] = false
			return res
		}

		return helper(i, j, 0)
	}

	res := make(map[string]bool)

	for i, row := range board {
		for j := range row {
			for _, word := range words {
				if board[i][j] == word[0] {
					if exist(i, j, word) {
						res[word] = true
					}
				}
			}
		}
	}

	ret := make([]string, 0, len(res))
	for word := range res {
		ret = append(ret, word)
	}
	return ret
}
