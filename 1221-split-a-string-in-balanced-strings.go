package main

func balancedStringSplit(s string) int {
	diff := 0
	res := 0
	for _, ch := range s {
		if ch == 'L' {
			diff++
		} else {
			diff--
		}
		if diff == 0 {
			res++
		}
	}
	return res
}
