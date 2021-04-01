public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        var sum = 0;
        var n = nums.Length;
        for (var i = 0; i < k; i++) sum += nums[i];
        var maxSum = sum;
        for (var i = k; i < n; i++) {
            sum = sum - nums[i - k] + nums[i];
            maxSum = Math.Max(maxSum, sum);
        }

        return 1.0 * maxSum / k;
    }
}