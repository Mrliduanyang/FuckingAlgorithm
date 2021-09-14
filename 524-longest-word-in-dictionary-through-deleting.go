package main

func findLongestWord(s string, dictionary []string) string {
	ret := ""
	for _, word := range dictionary {
		i := 0
		for j := range s {
			if s[j] == word[i] {
				i++
				if i == len(word) {
					if len(word) > len(ret) || (len(word) == len(ret) && word < ret) {
						ret = word
					}
					break
				}
			}
		}
	}
	return ret
}
