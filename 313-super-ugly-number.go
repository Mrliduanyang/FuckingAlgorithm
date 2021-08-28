package main

import (
	"container/heap"
	"sort"
)

func nthSuperUglyNumber(n int, primes []int) (ugly int) {
	seen := map[int]bool{1: true}
	h := &hp{[]int{1}}
	for i := 0; i < n; i++ {
		ugly = heap.Pop(h).(int)
		for _, prime := range primes {
			if next := ugly * prime; !seen[next] {
				seen[next] = true
				heap.Push(h, next)
			}
		}
	}
	return
}

// go里面的堆，可以对实现了heap.Interface中定义接口的数据类型提供堆操作，从而实现一个堆
// sort中预定义的排序类型，实现了Len，Less，Swap方法
type hp struct{ sort.IntSlice }

// 这里额外实现Push和Pop方法
func (h *hp) Push(v interface{}) { h.IntSlice = append(h.IntSlice, v.(int)) }
func (h *hp) Pop() interface{} {
	a := h.IntSlice
	v := a[len(a)-1]
	h.IntSlice = a[:len(a)-1]
	return v
}
