public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        if (intervals.Length == 0) return new[] {new[] {newInterval[0], newInterval[1]}};

        var n = intervals.Length;

        //用left和right记录新区间的左端和右端
        var left = newInterval[0];
        var right = newInterval[1];

        var isTrue = false;
        List<int[]> resultList = new List<int[]>();

        for (var i = 0; i < n; i++) {
            //找到left存在于原数组的哪个区间中，将左端对其。
            //left = 原属组区间的左端
            //可能right也在此区间，所以不continue
            if (left >= intervals[i][0] && left <= intervals[i][1]) left = intervals[i][0];

            //找到right在原数组的哪个区间中，右端对其。

            if (right >= intervals[i][0] && right <= intervals[i][1]) {
                right = intervals[i][1];
                continue;
            }

            //原数组的区间在新区间内，直接continue，不做记录。
            if (intervals[i][0] > left && intervals[i][0] < right) continue;

            //新区间之后的所有区间，记录进list中
            //第一次需要将新区间合并后的区间记录下来。
            if (intervals[i][0] > right) {
                if (!isTrue) {
                    resultList.Add(new[] {left, right});
                    isTrue = true;
                }

                resultList.Add(new[] {intervals[i][0], intervals[i][1]});
                continue;
            }

            //新区间之前的所有区间，记录进list中
            if (intervals[i][1] < left) {
                resultList.Add(new[] {intervals[i][0], intervals[i][1]});
            }
        }

        //若没有新区间之后的区间，
        //将合并后的新区间加到list中
        if (!isTrue) {
            resultList.Add(new[] {left, right});
            isTrue = true;
        }

        return resultList.ToArray();
    }
}