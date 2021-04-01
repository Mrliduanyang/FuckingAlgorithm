public class Solution {
    public int MinimumEffortPath(int[][] heights) {
        var right = 0;
        var left = int.MaxValue;
        var n = heights.Length;
        var k = heights[0].Length;
        //初始化体力消耗上限
        for (var i = 0; i < n; i++)
        for (var j = 0; j < k; j++) {
            if (i < n - 1) {
                right = Math.Max(right, Math.Abs(heights[i][j] - heights[i + 1][j]));
                left = Math.Min(left, Math.Abs(heights[i][j] - heights[i + 1][j]));
            }

            if (j < k - 1) {
                right = Math.Max(right, Math.Abs(heights[i][j] - heights[i][j + 1]));
                left = Math.Min(left, Math.Abs(heights[i][j] - heights[i][j + 1]));
            }
        }

        //二分查找最小消耗路径
        while (left < right) {
            var mid = left + ((right - left) >> 1);
            var uf = new Uf(n * k);
            for (var i = 0; i < n; i++)
            for (var j = 0; j < k; j++) {
                if (i < n - 1 && Math.Abs(heights[i][j] - heights[i + 1][j]) <= mid)
                    uf.Union(i * k + j, (i + 1) * k + j);
                if (j < k - 1 && Math.Abs(heights[i][j] - heights[i][j + 1]) <= mid) uf.Union(i * k + j, i * k + j + 1);
            }

            if (uf.Find(0) == uf.Find(n * k - 1))
                right = mid;
            else
                left = mid + 1;
        }

        return right;
    }

    public class Uf {
        public int c;
        private readonly int[] p;

        public Uf(int n) {
            p = new int[n];
            for (var i = 0; i < p.Length; i++) p[i] = i;
            c = n;
        }

        public Uf(Uf uf) {
            p = new int[uf.p.Length];
            for (var i = 0; i < p.Length; i++) p[i] = uf.p[i];
            c = uf.c;
        }

        public void Union(int x, int y) {
            var rootx = Find(x);
            var rooty = Find(y);
            if (rootx == rooty) return;
            p[rooty] = p[rootx];
        }

        public int Find(int y) {
            return p[y] == y ? y : p[y] = Find(p[y]);
        }
    }
}