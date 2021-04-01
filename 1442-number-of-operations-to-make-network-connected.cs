public class Solution {
    public int MakeConnected(int n, int[][] connections) {
        var uf = new Uf(n);
        var lines = 0;
        for (var i = 0; i < connections.Length; i++) {
            if (uf.count == 0) return 0;
            if (false == uf.Union(connections[i][0], connections[i][1])) lines++;
        }

        return lines >= uf.count - 1 ? uf.count - 1 : -1;
    }

    public class Uf {
        public int count;
        private readonly int[] p;

        public Uf(int n) {
            p = new int[n];
            count = n;
            for (var i = 0; i < n; i++) p[i] = i;
        }

        public bool Union(int x, int y) {
            var rootx = Find(x);
            var rooty = Find(y);
            if (rootx == rooty) return false;
            p[rooty] = p[rootx];
            count--;
            return true;
        }

        private int Find(int x) {
            return p[x] == x ? x : p[x] = Find(p[x]);
        }
    }
}