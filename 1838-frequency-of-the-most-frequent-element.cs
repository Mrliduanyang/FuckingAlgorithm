using System;

public class Solution {
    public int MaxFrequency(int[] nums, int k) {
        Array.Sort(nums);
         var n = nums.Length;
        long total = 0;
        int l = 0, res = 1;
        for (var r = 1; r < n; ++r) {
            total += (long) (nums[r] - nums[r - 1]) * (r - l);
            while (total > k) {
                total -= nums[r] - nums[l];
                ++l;
            }
            res = Math.Max(res, r - l + 1);
        }
        return res;
    }
}
