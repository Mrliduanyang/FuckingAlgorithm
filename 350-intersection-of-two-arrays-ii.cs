using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        // var shortNums = nums1.Length < nums2.Length ? nums1 : nums2;
        // var longNums = nums1.Length >= nums2.Length ? nums1 : nums2;
        // var dict = new Dictionary<int, int>();
        // foreach (var num in shortNums) dict[num] = dict.GetValueOrDefault(num, 0) + 1;
        // var res = new int[shortNums.Length];
        // var idx = 0;
        // foreach (var num in longNums) {
        //     var count = dict.GetValueOrDefault(num, 0);
        //     if (count > 0) {
        //         res[idx++] = num;
        //         count--;
        //         if (count > 0)
        //             dict[num] = count;
        //         else
        //             dict.Remove(num);
        //     }
        // }
        //
        // return res.Take(idx).ToArray();

        var res = new List<int>();
        Array.Sort(nums1);
        Array.Sort(nums2);
        int i = 0, j = 0;
        while (i < nums1.Length && j < nums2.Length) {
            if (nums1[i] < nums2[j]) {
                ++i;
            }
            else if (nums2[j] < nums1[i]) {
                ++j;
            }
            else {
                res.Add(nums1[i]);
                ++i;
                ++j;
            }
        }

        return res.ToArray();
    }
}