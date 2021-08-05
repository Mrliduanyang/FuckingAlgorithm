using System.Collections.Generic;

public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        var n = graph.Length;
        var color = new int[n];
        IList<int> ans = new List<int>();
        for (var i = 0; i < n; ++i) {
            if (Safe(graph, color, i)) {
                ans.Add(i);
            }
        }
        return ans;
    }

    public bool Safe(int[][] graph, int[] color, int x) {
        if (color[x] > 0) {
            return color[x] == 2;
        }
        color[x] = 1;
        foreach (var y in graph[x]) {
            if (!Safe(graph, color, y)) {
                return false;
            }
        }
        color[x] = 2;
        return true;
    }
}
