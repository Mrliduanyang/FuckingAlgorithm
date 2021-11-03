package main

import "container/heap"

func trapRainWater(heightMap [][]int) int {
	m, n := len(heightMap), len(heightMap[0])
	if m <= 2 || n <= 2 {
		return 0
	}

	vis := make([][]bool, m)
	for i := range vis {
		vis[i] = make([]bool, n)
	}

	h := &hp{}
	for i, row := range heightMap {
		for j, v := range row {
			if i == 0 || i == m-1 || j == 0 || j == n-1 {
				heap.Push(h, cell{v, i, j})
				vis[i][j] = true
			}
		}
	}

	ret := 0
	dirs := [][]int{{0, 1}, {0, -1}, {1, 0}, {-1, 0}}
	// Dijkstra最短路径
	for h.Len() > 0 {
		// 小顶堆，每次找最小的
		cur := heap.Pop(h).(cell)
		for _, dir := range dirs {
			x, y := cur.x+dir[0], cur.y+dir[1]
			if x >= 0 && x < m && y >= 0 && y < n && !vis[x][y] {
				// 以cur为墙，四周cell能存的水
				if heightMap[x][y] < cur.h {
					ret += (cur.h - heightMap[x][y])
				}
				vis[x][y] = true
				// 存上水后，登录四周cell的高度变了
				heap.Push(h, cell{max(heightMap[x][y], cur.h), x, y})
			}
		}
	}
	return ret
}

type cell struct {
	h, x, y int
}

type hp []cell

func (h hp) Len() int            { return len(h) }
func (h hp) Less(i, j int) bool  { return h[i].h < h[j].h }
func (h hp) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *hp) Push(v interface{}) { *h = append(*h, v.(cell)) }
func (h *hp) Pop() interface{} {
	a := *h
	v := a[len(a)-1]
	*h = a[:len(a)-1]
	return v
}

func max(a, b int) int {
	if a > b {
		return a
	}
	return b
}
