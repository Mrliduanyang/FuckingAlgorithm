package main

import (
	"container/heap"
	"sort"
)

type hp struct {
	sort.IntSlice
}

func (h *hp) Push(v interface{}) {
	h.IntSlice = append(h.IntSlice, v.(int))
}

func (h *hp) Pop() interface{} {
	a := h.IntSlice
	v := a[len(a)-1]
	h.IntSlice = a[:len(a)-1]
	return v
}

type MedianFinder struct {
	minHeap, maxHeap hp
}

/** initialize your data structure here. */
func Constructor() MedianFinder {
	return MedianFinder{}
}

func (this *MedianFinder) AddNum(num int) {
	// 大顶堆存前半部分，小顶堆存后半部分
	// 用负的小顶堆代替大顶堆
	minHeap, maxHeap := &this.minHeap, &this.maxHeap
	heap.Push(maxHeap, -num)
	heap.Push(minHeap, -heap.Pop(maxHeap).(int))
	if maxHeap.Len() < minHeap.Len() {
		heap.Push(maxHeap, -heap.Pop(minHeap).(int))
	}
}

func (this *MedianFinder) FindMedian() float64 {
	minHeap, maxHeap := &this.minHeap, &this.maxHeap
	if maxHeap.Len() == minHeap.Len() {
		return float64(minHeap.IntSlice[0]-maxHeap.IntSlice[0]) / 2
	} else {
		return float64(-maxHeap.IntSlice[0])
	}
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * obj := Constructor();
 * obj.AddNum(num);
 * param_2 := obj.FindMedian();
 */
