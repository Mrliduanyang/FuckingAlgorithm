using System;
using System.Collections;
using System.Collections.Generic;
public class Solution {
    public int[][] Merge(int[][] intervals) {
// 按区间start升序排列
                Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
                List<int[]> res = new List<int[]>();
                res.Add(intervals[0]);
                for (int i = 1; i < intervals.Length; i++) {
                    var curr = intervals[i];
                    // res中最后一个元素的引用，所以可以不断修改last的end。
                    var last = res.Last();
                    // 如果curr的start小于last的end，说明curr可能在last的区间内，这时需要比较curr的end和last的end，确定是否更新last的end。
                    if (curr[0] <= last[1]) {
                        last[1] = Math.Max(last[1], curr[1]);
                    } else {
                        res.Add(curr);
                    }
                }
                return res.ToArray();
    }
}