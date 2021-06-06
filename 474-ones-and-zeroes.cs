using System;
using System.Linq;

public class Solution {
    public int FindMaxForm(string[] strs, int m, int n) {
        var len = strs.Length;
        var dp = new int[len + 1, m + 1, n + 1];
        for (var i = 1; i <= len; ++i) {
            var zerosOnes = GetZerosOnes(strs[i - 1]);
            var zeros = zerosOnes[0];
            var ones = zerosOnes[1];
            for (var j = 0; j <= m; ++j) {
                for (var k = 0; k <= n; ++k) {
                    dp[i, j, k] = dp[i - 1, j, k];
                    if (j >= zeros && k >= ones) {
                        dp[i, j, k] = Math.Max(dp[i, j, k], dp[i - 1, j - zeros, k - ones] + 1);
                    }
                }
            }
        }

        return dp[len, m, n];
    }

    public int[] GetZerosOnes(string str) {
        var zerosOnes = new int[2];
        foreach (var ch in str) {
            zerosOnes[ch - '0']++;
        }

        return zerosOnes;
    }
}