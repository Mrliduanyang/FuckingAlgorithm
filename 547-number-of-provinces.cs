public class Solution {
    public int FindCircleNum(int[][] M) {
        int Find(int[] parent, int i) {
            // 寻找根
            if (parent[i] == -1)
                return i;
            return Find(parent, parent[i]);
        }

        void union(int[] parent, int x, int y) {
            var xP = Find(parent, x);
            var yP = Find(parent, y);
            if (xP != yP)
                parent[xP] = yP;
        }

        var parent = new int[M.Length];
        Array.Fill(parent, -1);
        for (var i = 0; i < M.Length; i++)
        for (var j = 0; j < M.Length; j++)
            if (M[i][j] == 1 && i != j)
                union(parent, i, j);
        var count = 0;
        for (var i = 0; i < parent.Length; i++)
            if (parent[i] == -1)
                count++;
        return count;
    }
}