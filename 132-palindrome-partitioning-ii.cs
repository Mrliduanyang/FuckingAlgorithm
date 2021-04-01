public class Solution {
    public int MinCut(string s) {
        var n = s.Length;
        var dp = new bool[n][];
        for (var i = 0; i < n; ++i) {
            dp[i] = new bool[n];
            Array.Fill(dp[i], true);
        }

        for (var i = n - 1; i >= 0; --i)
        for (var j = i + 1; j < n; ++j)
            dp[i][j] = s[i] == s[j] && dp[i + 1][j - 1];

        var f = new int[n];
        Array.Fill(f, int.MaxValue);
        for (var i = 0; i < n; ++i)
            if (dp[0][i])
                f[i] = 0;
            else
                for (var j = 0; j < i; ++j)
                    if (dp[j + 1][i])
                        f[i] = Math.Min(f[i], f[j] + 1);
        return f[n - 1];
    }
}