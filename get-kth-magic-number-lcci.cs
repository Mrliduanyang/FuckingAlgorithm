using System;

public class Solution {
    public int GetKthMagicNumber(int k) {
        var dp = new int[k + 1];
        dp[1] = 1;
        int p3 = 1, p5 = 1, p7 = 1;
        for (var i = 2; i <= k; i++) {
            int num3 = dp[p3] * 3, num5 = dp[p5] * 5, num7 = dp[p7] * 7;
            dp[i] = Math.Min(Math.Min(num3, num5), num7);
            if (dp[i] == num3) {
                p3++;
            }

            if (dp[i] == num5) {
                p5++;
            }

            if (dp[i] == num7) {
                p7++;
            }
        }

        return dp[k];
    }
}