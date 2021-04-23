using System;
using System.Collections.Generic;

public class Solution {
    public List<int> LargestDivisibleSubset(int[] nums) {
        var n = nums.Length;
        Array.Sort(nums);
        var dp = new int[n];
        Array.Fill(dp, 1);
        var maxSize = 1;
        var maxVal = dp[0];
        for (var i = 1; i < n; ++i) {
            for (var j = 0; j < i; ++j) {
                if (nums[i] % nums[j] == 0) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }

            if (dp[i] > maxSize) {
                maxSize = dp[i];
                maxVal = nums[i];
            }
        }

        var res = new List<int>();
        if (maxSize == 1) {
            res.Add(nums[0]);
            return res;
        }

        for (var i = n - 1; i >= 0 && maxSize > 0; --i) {
            if (dp[i] == maxSize && maxVal % nums[i] == 0) {
                res.Add(nums[i]);
                maxVal = nums[i];
                --maxSize;
            }
        }

        return res;
    }
}