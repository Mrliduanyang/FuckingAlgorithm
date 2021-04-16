public class Solution {
    public bool IsScramble(string s1, string s2) {
        if (s1.Length != s2.Length) {
            return false;
        }

        var n = s1.Length;
        var dp = new bool[n, n, n];
        for (var i = 0; i < n; i++) {
            for (var j = 0; j < n; j++) {
                dp[i, j, 0] = s1[i] == s2[j];
            }
        }

        for (var l = 1; l < n; l++) {
            for (var i = 0; i < n - l; i++) {
                for (var j = 0; j < n - l; j++) {
                    for (var w = 1; w < l + 1; w++) {
                        dp[i, j, l] |= dp[i, j, w - 1] && dp[i + w, j + w, l - w];
                        dp[i, j, l] |= dp[i, j + l - w + 1, w - 1] && dp[i + w, j, l - w];
                        if (dp[i, j, l]) {
                            break;
                        }
                    }
                }
            }
        }

        return dp[0, 0, n - 1];
    }
}