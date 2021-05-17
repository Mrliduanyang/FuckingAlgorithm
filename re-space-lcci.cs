using System;
using System.Collections.Generic;

public class Solution {
    public int Respace(string[] dictionary, string sentence) {
        var dict = new HashSet<string>(dictionary);
        var n = sentence.Length;
        var dp = new int[n - 1];
        for (var i = 1; i < n; ++i) {
            dp[i] = dp[i - 1] + 1;
            for (var j = 0; j < i; ++j) {
                if (dict.Contains(sentence[j..i])) {
                    dp[i] = Math.Min(dp[i], dp[j]);
                }
            }
        }

        return dp[n];
    }
}