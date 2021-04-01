public class Solution {
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList) {
        var res = new List<int[]>();
        int i = 0, j = 0;
        while (i < firstList.Length && j < secondList.Length) {
            int left = Math.Max(firstList[i][0], secondList[j][0]);
            int right = Math.Min(firstList[i][1], secondList[j][1]);
            if (left <= right) res.Add(new[] {left, right});
            if (firstList[i][1] < secondList[j][1])
                ++i;
            else
                ++j;
            ;
        }

        return res.ToArray();
    }
}