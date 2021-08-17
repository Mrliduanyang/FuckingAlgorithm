package main

func checkRecord(s string) bool {
	countA, countL := 0, 0
	for _, ch := range s {
		if ch == 'A' {
			countA++
			if countA >= 2 {
				return false
			}
		}

		if ch == 'L' {
			countL++
			if countL >= 3 {
				return false
			}
		} else {
			countL = 0
		}
	}
	return true
}
