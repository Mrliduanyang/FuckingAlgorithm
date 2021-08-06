using System;
using System.Collections.Generic;

public class Solution {
    public int ShortestPathLength(int[][] graph) {
        var n = graph.Length;
        var queue = new Queue<Tuple<int, int, int>>();
        var seen = new bool[n, 1 << n];
        for (var i = 0; i < n; ++i) {
            queue.Enqueue(new Tuple<int, int, int>(i, 1 << i, 0));
            seen[i, 1 << i] = true;
        }

        var ans = 0;
        while (queue.Count > 0) {
            var (u, mask, dist) = queue.Dequeue();
            if (mask == (1 << n) - 1) {
                ans = dist;
                break;
            }

            // 搜索相邻的节点
            foreach (var v in graph[u]) {
                // 将 mask 的第 v 位置为 1
                var maskV = mask | (1 << v);
                if (!seen[v, maskV]) {
                    queue.Enqueue(new Tuple<int, int, int>(v, maskV, dist + 1));
                    seen[v, maskV] = true;
                }
            }
        }

        return ans;
    }
}