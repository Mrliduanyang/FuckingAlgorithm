public class Solution {
    public int FindTargetSumWays(int[] nums, int S) {
                Dictionary<string, int> memo = new Dictionary<string, int>();
                int dp(int i, int rest) {
                    if (i == nums.Length) {
                        if (rest == 0) {
                            return 1;
                        }
                        return 0;
                    }
                    string key = i + "," + rest;
                    if (memo.ContainsKey(key)) {
                        return memo[key];
                    }
                    // 加上或者减去当前元素后，有多少种方案能凑出新的target
                    int result = dp(i + 1, rest - nums[i]) + dp(i + 1, rest + nums[i]);
                    memo.Add(key, result);
                    return result;
                }
                return dp(0, S);
    }
}