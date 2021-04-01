public class Solution {
    public int[][] ReconstructQueue(int[][] people) {
        /*
            排序+插入
            1. 排序：按照先H高度降序，K个数升序排序
            2. 插入：把矮个插入到 k 位置
        */

        Array.Sort(people, (p1, p2) => { return p1[0] == p2[0] ? p1[1] - p2[1] : p2[0] - p1[0]; });

        List<int[]> ans = new List<int[]>();
        foreach (var i in people) ans.Insert(i[1], i);

        return ans.ToArray();
    }
}