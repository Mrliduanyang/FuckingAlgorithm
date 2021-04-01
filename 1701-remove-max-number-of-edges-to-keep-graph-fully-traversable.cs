public class Solution {
    public int MaxNumEdgesToRemove(int n, int[][] edges) {
        //先添加公用边，然后分别处理Alice和Bob
        //可以并查集
        var uf = new Uf(n);
        var edgesA = new int[edges.Length][];
        var edgesB = new int[edges.Length][];
        var endA = 0;
        var endB = 0;
        var result = 0;
        for (var i = 0; i < edges.Length; i++) {
            var type = edges[i][0];
            switch (type) {
                case 1:
                    edgesA[endA] = new[] {edges[i][1] - 1, edges[i][2] - 1};
                    endA++;
                    break;
                case 2:
                    edgesB[endB] = new[] {edges[i][1] - 1, edges[i][2] - 1};
                    endB++;
                    break;
                case 3:
                    if (false == uf.Union(edges[i][1] - 1, edges[i][2] - 1)) result++;
                    break;
            }
        }

        var ufB = new Uf(uf);
        for (var i = 0; i < endA; i++)
            if (false == uf.Union(edgesA[i][0], edgesA[i][1]))
                result++;
        if (uf.c != 1) return -1;
        for (var i = 0; i < endB; i++)
            if (false == ufB.Union(edgesB[i][0], edgesB[i][1]))
                result++;
        return ufB.c == 1 ? result : -1;
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

        public bool Union(int x, int y) {
            var rootx = Find(x);
            var rooty = Find(y);
            if (rootx == rooty) return false;
            p[rooty] = p[rootx];
            c--;
            return true;
        }

        private int Find(int y) {
            return p[y] == y ? y : p[y] = Find(p[y]);
        }
    }
}