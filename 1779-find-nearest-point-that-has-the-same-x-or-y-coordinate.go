package main

func abs(n int) int {
	if n < 0 {
		n = -n
	}
	return n
}
func nearestValidPoint(x int, y int, points [][]int) int {
	idx := -1
	max_dis := 10000000000
	for i := 0; i < len(points); i++ {
		if points[i][0] == x || points[i][1] == y {
			dis := abs(x-points[i][0]) + abs(y-points[i][1])
			if dis < max_dis {
				max_dis = dis
				idx = i
			}
		}
	}
	return idx
}
