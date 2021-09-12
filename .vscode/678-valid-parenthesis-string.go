package main

func checkValidString(s string) bool {
	var leftStack, starStack []int
	for i, ch := range s {
		if ch == '(' {
			leftStack = append(leftStack, i)
		} else if ch == '*' {
			starStack = append(starStack, i)
		} else {
			if len(leftStack) != 0 {
				leftStack = leftStack[:len(leftStack)-1]
			} else if len(starStack) > 0 {
				starStack = starStack[:len(starStack)-1]
			} else {
				return false
			}

		}
	}
	i := len(leftStack) - 1
	for j := len(starStack) - 1; i >= 0 && j >= 0; i, j = i-1, j-1 {
		if leftStack[i] > starStack[j] {
			return false
		}
	}
	return i < 0
}
