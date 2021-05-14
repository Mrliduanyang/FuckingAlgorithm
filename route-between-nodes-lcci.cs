using System.Collections.Generic;

public class Solution {
    public bool FindWhetherExistsPath(int n, int[][] graph, int start, int target) {
        if (start == target) return true;
        var dict = new Dictionary<int, HashSet<int>>();
        foreach (var edge in graph) {
            if (!dict.ContainsKey(edge[0])) {
                dict[edge[0]] = new HashSet<int>();
            }

            if (edge[0] != edge[1]) {
                dict[edge[0]].Add(edge[1]);
            }
        }

        bool Helper(int cur) {
            if (!dict.ContainsKey(cur)) return false;
            if (dict[cur].Contains(target)) return true;
            foreach (var node in dict[cur]) {
                if (Helper(node)) return true;
            }

            return false;
        }

        return Helper(start);
    }
}