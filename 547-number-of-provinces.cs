using System;
using System.Linq;

public class Solution {
    public int FindCircleNum(int[][] M) {
        var parent = new int[M.Length];

        int Find(int i) {
            if (parent[i] == -1)
                return i;
            return Find(parent[i]);
        }

        void Union(int x, int y) {
            var xP = Find(x);
            var yP = Find(y);
            if (xP != yP)
                parent[xP] = yP;
        }

        Array.Fill(parent, -1);
        for (var i = 0; i < M.Length; i++)
        for (var j = 0; j < M.Length; j++)
            if (M[i][j] == 1 && i != j)
                Union(i, j);
        return parent.Count(x => x == -1);
    }
}