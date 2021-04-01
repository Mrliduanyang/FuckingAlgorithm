public class Solution {
    public int LongestPalindromeSubseq(string s) {
                int n = s.Length;
                // 涉及两个字符串，用二维dp数组
                // dp定义为在array[i..j]中，最长回文子序列的长度为dp[i][j]
                int[, ] dp = new int[n, n];
                // base如果只有一个字符，最长回文子序列长度为1
                for (int i = 0; i < n; i++) {
                    dp[i, i] = 1;
                }
                // 要求dp[0,n-1]，斜着遍历或者反着遍历
                for (int i = n - 1; i >= 0; i--) {
                    // j比i大
                    for (int j = i + 1; j < n; j++) {
                        if (s[i] == s[j]) {
                            // 如果s[i]和s[j]字符相同，最长回文子序列长度加2
                            dp[i, j] = dp[i + 1, j - 1] + 2;
                        } else {
                            // 反之，将两个字符分别添加上，比较长度
                            dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                        }
                    }
                }
                return dp[0, n - 1];
    }
}