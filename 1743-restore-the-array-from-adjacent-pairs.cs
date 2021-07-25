using System.Collections.Generic;

public class Solution {
    public int[] RestoreArray(int[][] adjacentPairs) {
        var dict = new Dictionary<int, List<int>>();
        foreach (var adjacentPair in adjacentPairs) {
            var first = adjacentPair[0];
            var second = adjacentPair[1];
            if (!dict.ContainsKey(first)) {
                dict[first] = new List<int>();
            }

            if (!dict.ContainsKey(second)) {
                dict[second] = new List<int>();
            }

            dict[first].Add(second);
            dict[second].Add(first);
        }

        var n = adjacentPairs.Length + 1;
        var res = new int[n];
        foreach (var (key, val) in dict) {
            if (val.Count == 1) {
                res[0] = key;
                break;
            }
        }

        res[1] = dict[res[0]][0];
        for (var i = 2; i < n; i++) {
            var adj = dict[res[i - 1]];
            res[i] = res[i - 2] == adj[0] ? adj[1] : adj[0];
        }

        return res;
    }
}