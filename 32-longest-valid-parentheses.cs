public class Solution {
    public int LongestValidParentheses(string s) {
        var maxans = 0;
        var dp = new int[s.Length];
        for (var i = 1; i < s.Length; i++)
            if (s[i] == ')') {
                if (s[i - 1] == '(')
                    dp[i] = (i >= 2 ? dp[i - 2] : 0) + 2;
                else if (i - dp[i - 1] > 0 && s[i - dp[i - 1] - 1] == '(')
                    dp[i] = dp[i - 1] + (i - dp[i - 1] >= 2 ? dp[i - dp[i - 1] - 2] : 0) + 2;
                maxans = Math.Max(maxans, dp[i]);
            }

        return maxans;
    }
}