public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        var dp = new int[target + 1];

        int Helper(int target) {
            if (target == 0) return 1;
            if (dp[target] >= 0) return dp[target];
            var count = 0;
            for (var i = 0; i < nums.Length; i++)
                if (target >= nums[i])
                    count += Helper(target - nums[i]);
            dp[target] = count;
            return count;
        }

        Array.Sort(nums);
        for (var i = 0; i < dp.Length; i++) dp[i] = -1;
        var count = Helper(target);
        return count;
    }
}