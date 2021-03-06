public class Solution {
    public bool IsMatch(string s, string p) {
        int m = s.Length, n = p.Length;
        var dp = new bool[m + 1, n + 1];
        dp[0, 0] = true;

        bool matches(int i, int j) {
            if (i == 0) return false;
            if (p[j - 1] == '.') return true;
            return s[i - 1] == p[j - 1];
        }

        for (var i = 0; i <= m; ++i)
        for (var j = 1; j <= n; ++j)
            if (p[j - 1] == '*') {
                dp[i, j] = dp[i, j - 2];
                if (matches(i, j - 1)) dp[i, j] = dp[i, j] || dp[i - 1, j];
            }
            else {
                if (matches(i, j)) dp[i, j] = dp[i - 1, j - 1];
            }

        return dp[m, n];
    }
}