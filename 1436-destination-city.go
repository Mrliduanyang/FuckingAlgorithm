package main

func destCity(paths [][]string) string {
	citiesA := map[string]bool{}
	for _, city := range paths {
		citiesA[city[0]] = true
	}
	for _, city := range paths {
		if !citiesA[city[1]] {
			return city[1]
		}
	}
	return ""
}
