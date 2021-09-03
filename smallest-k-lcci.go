package main

import (
	"container/heap"
	"sort"
)

func smallestK(arr []int, k int) []int {
	if k == 0 {
		return nil
	}
	h := &hp{arr[:k]}
	heap.Init(h)
	for _, v := range arr[k:] {
		if h.IntSlice[0] > v {
			h.IntSlice[0] = v
			heap.Fix(h, 0)
		}
	}
	return h.IntSlice
}

type hp struct{ sort.IntSlice }

// 维护大顶堆，重写了Less
func (h hp) Less(i, j int) bool { return h.IntSlice[i] > h.IntSlice[j] }

// Push和Pop没用，但要实现
func (hp) Push(interface{})     {}
func (hp) Pop() (_ interface{}) { return }
