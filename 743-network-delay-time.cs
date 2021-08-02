using System;
using System.Linq;

public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        const int INF = int.MaxValue / 2;
        var g = new int[n, n];
        for (var i = 0; i < n; ++i) {
            for (var j = 0; j < n; ++j) {
                g[i, j] = INF;
            }
        }

        foreach (var time in times) {
            var src = time[0] - 1;
            var dst = time[1] - 1;
            g[src, dst] = time[2];
        }

        var dist = new int[n];
        Array.Fill(dist, INF);
        dist[k - 1] = 0;
        var vis = new bool[n];
        for (var i = 0; i < n; ++i) {
            var x = -1;
            // 找到dist里最小的点
            for (var y = 0; y < n; ++y) {
                if (!vis[y] && (x == -1 || dist[y] < dist[x])) {
                    x = y;
                }
            }

            vis[x] = true;

            for (var y = 0; y < n; ++y) {
                dist[y] = Math.Min(dist[y], dist[x] + g[x, y]);
            }
        }

        var res = dist.Max();
        return res == INF ? -1 : res;
    }
}