using System.Collections.Generic;

public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        var n = graph.Length;
        var color = new int[n];

        // 双色标记法，
        bool Safe(int x) {
            // 如果有环，会被再次搜索到，如果是通过环的方式，不安全；如果是非环的方式（通过其他路径过来的），安全
            if (color[x] > 0) {
                return color[x] == 2;
            }
            // 第一次搜索标记为1
            color[x] = 1;
            foreach (var y in graph[x]) {
                // 递归搜索所有经过x节点可达的路径
                if (!Safe(y)) {
                    return false;
                }
            }
            // 一条路径深度搜索以后（递归结束以后），没有遇见环，则该节点是安全的
            color[x] = 2;
            return true;
        }

        IList<int> ans = new List<int>();
        for (var i = 0; i < n; ++i) {
            if (Safe(i)) {
                ans.Add(i);
            }
        }

        return ans;
    }
}