package main

func escapeGhosts(ghosts [][]int, target []int) bool {
	player := []int{0, 0}
	playerDis := distance(player, target)
	for _, ghost := range ghosts {
		if distance(ghost, target) <= playerDis {
			return false
		}
	}
	return true
}

func distance(source, target []int) int {
	return abs(source[0]-target[0]) + abs(source[1]-target[1])
}

func abs(x int) int {
	if x < 0 {
		return -x
	}
	return x
}
