public class Solution {
    public int NumDecodings(string s) {
                if (s[0] == '0') return 0;
                var dp = new int[s.Length + 1];
                dp[0] = dp[1] = 1;
                for (int i = 1; i < s.Length; i++) {
                    if (s[i] == '0') {
                        if (s[i - 1] == '1' || s[i - 1] == '2') {
                            dp[i + 1] = dp[i - 1];
                        } else {
                            return 0;
                        }
                    } else if (s[i - 1] == '1' || (s[i - 1] == '2' && s[i] >= '1' && s[i] <= '6')) {
                        dp[i + 1] = dp[i] + dp[i - 1];
                    } else {
                        dp[i + 1] = dp[i];
                    }
                }
                return dp.Last();

    }
}
