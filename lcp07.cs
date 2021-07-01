using System.Collections.Generic;

public class Solution {
    public int NumWays(int n, int[][] relation, int k) {
        var edges = new List<List<int>>();
        for (var i = 0; i < n; ++i) {
            edges.Add(new List<int>());
        }

        foreach (var item in relation) {
            var source = item[0];
            var target = item[1];
            edges[source].Add(target);
        }

        var res = 0;

        void Helper(int idx, int steps) {
            if (steps == k) {
                if (idx == n - 1) {
                    ++res;
                }
                return;
            }

            foreach (var next in edges[idx]) {
                Helper(next, steps + 1);
            }
        }

        Helper(0, 0);
        return res;
    }
}