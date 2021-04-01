public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
                Array.Sort(envelopes, (x, y) => {
                    if (x[0] == y[0]) {
                        return y[1] - x[1];
                    } else {
                        return x[0] - y[0];
                    }
                });
                var secDim = envelopes.Select(x => x[1]).ToArray();
                var dp = new int[secDim.Length];
                var res = 0;
                Array.Fill(dp, 1);
                for (int i = 0; i < secDim.Length; i++) {
                    for (int j = 0; j < i; j++) {
                        if (secDim[i] > secDim[j]) {
                            dp[i] = Math.Max(dp[i], dp[j] + 1);
                        }
                    }
                    res = Math.Max(res, dp[i]);
                }
                return res;
    }
}