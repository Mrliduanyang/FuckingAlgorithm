public class Solution {
    public bool IsMatch(string s, string p) {
        int m = s.Length, n = p.Length;
        var dp = new bool[m + 1, n + 1];
        dp[0, 0] = true;
        for (var i = 1; i <= n; ++i)
            if (p[i - 1] == '*')
                dp[0, i] = true;
            else
                break;
        for (var i = 1; i <= m; ++i)
        for (var j = 1; j <= n; j++)
            if (p[j - 1] == '*')
                dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
            else if (p[j - 1] == '?' || s[i - 1] == p[j - 1]) dp[i, j] = dp[i - 1, j - 1];
        return dp[m, n];
    }
}