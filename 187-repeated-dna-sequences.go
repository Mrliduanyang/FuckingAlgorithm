package main

func findRepeatedDnaSequences(s string) []string {
	ret := []string{}
	dict := map[string]int{}

	for i := 0; i <= len(s)-10; i++ {
		segment := s[i : i+10]
		dict[segment]++
		if dict[segment] == 2 {
			ret = append(ret, segment)
		}
	}
	return ret
}
