using System;

public class Solution {
    public int MinPairSum(int[] nums) {
        var n = nums.Length;
        var res = 0;
        Array.Sort(nums);
        for (var i = 0; i < n / 2; ++i) {
            res = Math.Max(res, nums[i] + nums[n - 1 - i]);
        }

        return res;
    }
}