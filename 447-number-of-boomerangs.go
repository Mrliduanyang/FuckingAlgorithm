package main

func numberOfBoomerangs(points [][]int) int {
	ret := 0
	for _, p := range points {
		dict := map[int]int{}
		for _, q := range points {
			dis := (p[0]-q[0])*(p[0]-q[0]) + (p[1]-q[1])*(p[1]-q[1])
			dict[dis]++
		}

		for _, m := range dict {
			ret += m * (m - 1)
		}
	}
	return ret
}
