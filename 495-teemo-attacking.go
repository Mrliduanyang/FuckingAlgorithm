package main

func findPoisonedDuration(timeSeries []int, duration int) (ans int) {
	expired := 0
	for _, t := range timeSeries {
		if t >= expired {
			ans += duration
		} else {
			ans += t + duration - expired
		}
		expired = t + duration
	}
	return
}
