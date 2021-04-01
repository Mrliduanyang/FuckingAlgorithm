public class Solution {
    public string ShortestPalindrome(string s) {
        var n = s.Length;
        int myBase = 131, mod = 1000000007;
        int left = 0, right = 0, mul = 1;
        var best = -1;
        for (var i = 0; i < n; ++i) {
            left = (int) (((long) left * myBase + s[i]) % mod);
            right = (int) ((right + (long) mul * s[i]) % mod);
            if (left == right) best = i;
            mul = (int) ((long) mul * myBase % mod);
        }

        var add = best == n - 1 ? "" : s[(best + 1)..];
        var res = new StringBuilder(string.Join("", add.Reverse()));
        res.Append(s);
        return res.ToString();
    }
}