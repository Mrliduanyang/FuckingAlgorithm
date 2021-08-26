package main

import "sort"

func numRescueBoats(people []int, limit int) int {
	sort.Ints(people)
	light, heavy := 0, len(people)-1
	res := 0
	for light <= heavy {
		if people[light]+people[heavy] <= limit {
			light++
		}
		heavy--
		res++
	}
	return res
}

func main() {
	numRescueBoats([]int{1, 2}, 3)
}
