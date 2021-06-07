public class Solution {
    public int FindTargetSumWays(int[] nums, int S) {
        var res = 0;

        void Helper(int idx, int sum) {
            if (idx == nums.Length) {
                if (sum == S) ++res;
            }
            else {
                Helper(idx + 1, sum + nums[idx]);
                Helper(idx + 1, sum - nums[idx]);
            }
        }

        Helper(0, 0);
        return res;
    }
}