package main

func isValid(str string) bool {
	cnt := 0
	for _, ch := range str {
		if ch == '(' {
			cnt++
		} else if ch == ')' {
			cnt--
			if cnt < 0 {
				return false
			}
		}
	}
	return cnt == 0
}

func removeInvalidParentheses(s string) []string {
	ret := []string{}
	curSet := map[string]struct{}{s: {}}
	for {
		for str := range curSet {
			if isValid(str) {
				ret = append(ret, str)
			}
		}
		if len(ret) > 0 {
			return ret
		}
		nextSet := map[string]struct{}{}
		for str := range curSet {
			for i, ch := range str {
				if i > 0 && byte(ch) == str[i-1] {
					continue
				}
				if ch == '(' || ch == ')' {
					nextSet[str[:i]+str[i+1:]] = struct{}{}
				}
			}
		}
		curSet = nextSet
	}
}
