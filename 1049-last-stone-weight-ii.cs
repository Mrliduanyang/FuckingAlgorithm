using System;
using System.Linq;

public class Solution {
    public int LastStoneWeightII(int[] stones) {
        var n = stones.Length;
        var sum = stones.Sum();
        var target = sum / 2;
        var dp = new int[n + 1, target + 1];
        for (var i = 1; i <= n; ++i) {
            var stone = stones[i];
            for (var j = 0; j <= target; ++j) {
                dp[i, j] = dp[i - 1, j];
                if (j >= stone) {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - stone] + stone);
                }
            }
        }

        return Math.Abs(sum - dp[n, target] * 2);
    }
}