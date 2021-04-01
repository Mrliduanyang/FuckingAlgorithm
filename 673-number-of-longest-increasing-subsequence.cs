public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        var dp = new int[nums.Length];
        var counter = new int[nums.Length];
        Array.Fill(dp, 1);
        Array.Fill(counter, 1);
        var max = -1;
        for (var i = 0; i < nums.Length; i++) {
            for (var j = 0; j < i; j++)
                if (nums[i] > nums[j]) {
                    if (dp[j] + 1 > dp[i]) {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        counter[i] = counter[j];
                    }
                    else if (dp[j] + 1 == dp[i]) {
                        counter[i] += counter[j];
                    }
                }

            max = Math.Max(max, dp[i]);
        }

        var res = 0;
        for (var i = 0; i < nums.Length; i++)
            if (dp[i] == max)
                res += counter[i];

        return res;
    }
}