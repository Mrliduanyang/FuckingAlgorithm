package main

import (
	"strings"
)

func reorderSpaces(text string) string {
	n := len(text)
	words := make([]string, 0)
	slow, fast := 0, 0
	spaceCount := 0
	for fast < n {
		if text[fast] == ' ' {
			spaceCount++
			fast++
			slow++
		} else {
			for fast < n && text[fast] != ' ' {
				fast++
			}
			words = append(words, text[slow:fast])
			slow = fast
		}
	}
	wordsCount := len(words)
	gapCount := wordsCount - 1
	if gapCount < 1 {
		return words[0] + strings.Repeat(" ", spaceCount)
	}
	spaceGap := spaceCount / gapCount
	res := strings.Join(words, strings.Repeat(" ", spaceGap))
	res = res + strings.Repeat(" ", spaceCount-spaceGap*gapCount)
	return res
}
