package main

import (
	"container/heap"
	"sort"
)

type hp struct {
	sort.IntSlice
}

func (h hp) Less(i, j int) bool {
	return h.IntSlice[i] > h.IntSlice[j]
}
func (h *hp) Push(val interface{}) {
	h.IntSlice = append(h.IntSlice, val.(int))
}
func (h *hp) Pop() interface{} {
	a := h.IntSlice
	v := a[len(a)-1]
	h.IntSlice = a[:len(a)-1]
	return v
}

func findMaximizedCapital(k int, w int, profits []int, capital []int) int {
	n := len(profits)
	type pair struct {
		cost, profit int
	}

	arr := make([]pair, n)
	for i, profit := range profits {
		arr[i] = pair{capital[i], profit}
	}

	sort.Slice(arr, func(i, j int) bool { return arr[i].cost < arr[j].cost })

	h := &hp{}
	for cur := 0; k > 0; k-- {
		for cur < n && arr[cur].cost <= w {
			heap.Push(h, arr[cur].profit)
			cur++
		}
		if h.Len() == 0 {
			break
		}
		w += heap.Pop(h).(int)
	}
	return w
}
