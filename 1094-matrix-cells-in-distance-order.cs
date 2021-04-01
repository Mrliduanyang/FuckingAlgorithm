public class Solution {
    public int[][] AllCellsDistOrder(int R, int C, int r0, int c0) {
        if (R == 0 || C == 0) return new int[0][] { };
        ;
        var res = new List<int[]>();
        var queue = new Queue<int[]>();
        var vis = new Dictionary<string, bool>();
        // 搜索上下左右的常用技巧
        int[] dx = {0, 1, 0, -1};
        int[] dy = {1, 0, -1, 0};
        queue.Enqueue(new[] {r0, c0});
        vis[$"{r0},{c0}"] = true;
        while (queue.Count != 0) {
            var count = queue.Count;
            for (var i = 0; i < count; i++) {
                var cur = queue.Dequeue();
                res.Add(cur);
                for (var k = 0; k < 4; k++) {
                    var tx = cur[0] + dx[k];
                    var ty = cur[1] + dy[k];
                    if (tx >= 0 && tx < R && ty >= 0 && ty < C) {
                        var tmp = new[] {tx, ty};
                        var pos = string.Join(",", tmp);
                        if (!vis.ContainsKey(pos)) {
                            queue.Enqueue(tmp);
                            vis[pos] = true;
                        }
                    }
                }
            }
        }

        return res.ToArray();
    }
}