package main

func isPerfectSquare(num int) bool {
	left, right := 0, num+1
	for left < right {
		mid := left + (right-left)/2
		square := mid * mid
		if square < num {
			left = mid + 1
		} else if square > num {
			right = mid
		} else {
			return true
		}
	}
	return false
}
