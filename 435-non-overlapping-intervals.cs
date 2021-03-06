public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if (intervals.Length == 0) return 0;
        Array.Sort(intervals, (a, b) => { return a[1] < b[1] ? -1 : 1; });
        var count = 1;
        var end = intervals[0][1];
        foreach (var interval in intervals) {
            var start = interval[0];
            if (start >= end) {
                count++;
                end = interval[1];
            }
        }

        return intervals.Length - count;
    }
}