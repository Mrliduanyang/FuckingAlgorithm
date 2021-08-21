package main

import (
	"strconv"
)

func compress(chars []byte) int {
	n := len(chars)
	slow, fast, cur := 0, 0, 0
	for fast <= n {
		if fast == n || chars[fast] != chars[slow] {
			chars[cur] = chars[slow]
			cur++
			if (fast - slow) >= 2 {
				for _, ch := range strconv.Itoa(fast - slow) {
					chars[cur] = byte(ch)
					cur++
				}
			}
			slow = fast
		}
		fast++
	}
	return cur
}

func main() {
	compress([]byte{'a', 'a', 'b', 'b', 'c', 'c', 'c'})
}
