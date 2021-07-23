using System;

public class Solution {
    public bool IsCovered(int[][] ranges, int left, int right) {
        Array.Sort(ranges, (x, y) => x[0] - y[0]);
        foreach (var range in ranges) {
            var l = range[0];
            var r = range[1];
            if (l <= left && left <= r) {
                left = r + 1;
            }
        }

        return left > right;
    }
}