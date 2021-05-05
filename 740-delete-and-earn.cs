using System;

public class Solution {
    public int DeleteAndEarn(int[] nums) {
        var bucket = new int[10001];
        foreach (var num in nums) bucket[num] += num;
        var dp = new int[10001];
        dp[1] = bucket[1];
        for (var i = 2; i <= 10000; i++) {
            dp[i] = Math.Max(dp[i - 2] + bucket[i], dp[i - 1]);
        }

        return dp[10000];
    }
}