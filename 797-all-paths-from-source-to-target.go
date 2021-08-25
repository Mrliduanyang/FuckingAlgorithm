package main

func allPathsSourceTarget(graph [][]int) [][]int {
	var res [][]int
	path := []int{0}
	var helper func(int)
	helper = func(x int) {
		if x == len(graph)-1 {
			//res = append(res, append([]int(nil), path...))
			res = append(res, path)
			return
		}
		for _, y := range graph[x] {
			path = append(path, y)
			helper(y)
			path = path[:len(path)-1]
		}
	}
	helper(0)
	return res
}
