public class Solution {
    public int RemoveStones(int[][] stones) {
        //一个连通分量一定可以删到只剩一个石头
        // |
        // v
        //确定连通分量数 -> 答案
        //构建图，DFS
        var uf = new Uf(20002);
        for (var i = 0; i < stones.Length; i++) uf.Union(stones[i][0] + 10001, stones[i][1]);
        HashSet<int> ccs = new HashSet<int>();
        for (var i = 0; i < stones.Length; i++) {
            var a = uf.Find(stones[i][1]);
            if (ccs.Contains(uf.Find(stones[i][1])) == false) ccs.Add(a);
        }

        return stones.Length - ccs.Count();
    }

    public class Uf {
        private readonly int[] p;

        public Uf(int size) {
            p = new int[size];
            for (var i = 0; i < size; i++) p[i] = i;
        }

        public void Union(int x, int y) {
            var a = Find(x);
            var b = Find(y);
            if (a != b) p[a] = b;
        }

        public int Find(int x) {
            return p[x] == x ? x : p[x] = Find(p[x]);
        }
    }
}