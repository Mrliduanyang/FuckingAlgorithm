package main

func unhappyFriends(n int, preferences [][]int, pairs [][]int) int {
	order := make([][]int, n)
	for i, preference := range preferences {
		order[i] = make([]int, n)
		for j, p := range preference {
			order[i][p] = j
		}
	}

	match := make([]int, n)
	for _, p := range pairs {
		match[p[0]] = p[1]
		match[p[1]] = p[0]
	}

	res := 0
	for x, y := range match {
		idx := order[x][y]
		for _, u := range preferences[x][:idx] {
			v := match[u]
			if order[u][x] < order[u][v] {
				res++
				break
			}
		}
	}
	return res
}
