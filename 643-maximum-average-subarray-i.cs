public class Solution {
            public double FindMaxAverage(int[] nums, int k) {
                int sum = 0;
                int n = nums.Length;
                for (int i = 0; i < k; i++) {
                    sum += nums[i];
                }
                int maxSum = sum;
                for (int i = k; i < n; i++) {
                    sum = sum - nums[i - k] + nums[i];
                    maxSum = Math.Max(maxSum, sum);
                }
                return 1.0 * maxSum / k;
            }
}