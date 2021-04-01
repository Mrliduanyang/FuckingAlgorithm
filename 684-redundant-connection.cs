public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        var nodesCount = edges.Length;
        var parent = new int[nodesCount + 1];
        for (var i = 1; i <= nodesCount; i++) parent[i] = i;

        void Union(int x, int y) {
            var px = Find(x);
            var py = Find(y);
            if (px == py) return;
            parent[px] = py;
        }

        int Find(int x) {
            if (parent[x] == x) return x;
            return Find(parent[x]);
        }

        for (var i = 0; i < nodesCount; i++) {
            var edge = edges[i];
            int node1 = edge[0], node2 = edge[1];
            if (Find(node1) != Find(node2))
                Union(node1, node2);
            else
                return edge;
        }

        return new int[0];
    }
}