public class Solution {
    public int FindLength(int[] A, int[] B) {
                int n = A.Length, m = B.Length;
                int[, ] dp = new int[n + 1, m + 1];
                int ans = 0;
                for (int i = n - 1; i >= 0; i--) {
                    for (int j = m - 1; j >= 0; j--) {
                        dp[i,j] = A[i] == B[j] ? dp[i + 1,j + 1] + 1 : 0;
                        ans = Math.Max(ans, dp[i,j]);
                    }
                }
                return ans;
    }
}