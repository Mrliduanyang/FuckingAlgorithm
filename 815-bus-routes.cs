using System;
using System.Collections.Generic;

public class Solution {
    public int NumBusesToDestination(int[][] routes, int source, int target) {
        if (source == target) return 0;
        var n = routes.Length;
        var edge = new bool[n, n];
        var dict = new Dictionary<int, List<int>>();
        for (var i = 0; i < n; ++i) {
            foreach (var site in routes[i]) {
                var list = new List<int>();
                if (dict.ContainsKey(site)) {
                    list = dict[site];
                    foreach (var j in list) {
                        edge[i, j] = edge[j, i] = true;
                    }

                    dict[site].Add(i);
                }
                else {
                    list.Add(i);
                    dict[site] = list;
                }
            }
        }

        var dis = new int[n];
        Array.Fill(dis, -1);
        var queue = new Queue<int>();
        if (dict.ContainsKey(source)) {
            foreach (var bus in dict[source]) {
                dis[bus] = 1;
                queue.Enqueue(bus);
            }
        }

        while (queue.Count != 0) {
            var cur = queue.Dequeue();
            for (var tar = 0; tar < n; ++tar) {
                if (edge[cur, tar] && dis[tar] == -1) {
                    dis[tar] = dis[cur] + 1;
                    queue.Enqueue(tar);
                }
            }
        }

        var res = int.MaxValue;
        if (dict.ContainsKey(target)) {
            foreach (var bus in dict[target]) {
                if (dis[bus] != -1) {
                    res = Math.Min(res, dis[bus]);
                }
            }
        }

        return res == int.MaxValue ? -1 : res;
    }
}