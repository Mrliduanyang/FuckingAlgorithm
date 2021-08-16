package main

func countArrangement(n int) int {
	res := 0
	vis := make([]bool, n+1)
	var helper func(int)
	helper = func(idx int) {
		if idx == n+1 {
			res++
			return
		}
		for i := 1; i <= n; i++ {
			if !vis[i] && (i%idx == 0 || idx%i == 0) {
				vis[i] = true
				helper(idx + 1)
				vis[i] = false
			}
		}
	}

	helper(1)
	return res
}
