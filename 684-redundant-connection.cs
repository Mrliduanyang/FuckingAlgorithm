public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
int nodesCount = edges.Length;
                int[] parent = new int[nodesCount + 1];
                for (int i = 1; i <= nodesCount; i++) {
                    parent[i] = i;
                }
                void Union(int x, int y) {
                    int px = Find(x);
                    int py = Find(y);
                    if (px == py) {
                        return;
                    }
                    parent[px] = py;
                }

                int Find(int x) {
                    if (parent[x] == x) {
                        return x;
                    }
                    return Find(parent[x]);
                }

                for (int i = 0; i < nodesCount; i++) {
                    int[] edge = edges[i];
                    int node1 = edge[0], node2 = edge[1];
                    if (Find(node1) != Find(node2)) {
                        Union(node1, node2);
                    } else {
                        return edge;
                    }
                }
                return new int[0];
    }
}