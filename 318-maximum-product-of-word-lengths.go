package main

func maxProduct(words []string) int {
	masks := make([]int, len(words))
	for i, word := range words {
		for _, ch := range word {
			masks[i] |= 1 << (ch - 'a')
		}
	}
	ret := 0
	for i, x := range masks {
		for j, y := range masks[:i] {
			if x&y == 0 && len(words[i])*len(words[j]) > ret {
				ret = len(words[i]) * len(words[j])
			}
		}
	}
	return ret
}
