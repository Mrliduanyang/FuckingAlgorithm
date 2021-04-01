public class Solution {
    public int MinDistance(string word1, string word2) {
                int Min(int a, int b, int c) {
                    return Math.Min(Math.Min(a, b), c);
                }
                
                int m = word1.Length, n = word2.Length;
                int[,] dp = new int[m + 1, n + 1];
                // base，“”到m的编辑距离为0-m，“”到n的编辑距离为0-n
                for (int i = 0; i <= m; i++) dp[i, 0] = i;
                for (int i = 0; i <= n; i++) dp[0, i] = i;

                for (int i = 1; i <= m; i++) {
                    for (int j = 1; j <= n; j++) {
                        if (word1[i - 1] == word2[j - 1]) {
                            dp[i, j] = dp[i - 1, j - 1];
                        } else {
                            dp[i, j] = Min(
                                dp[i - 1, j] + 1,
                                dp[i, j - 1] + 1,
                                dp[i - 1, j - 1] + 1
                            );
                        }
                    }
                }
                return dp[m, n];
    }
}