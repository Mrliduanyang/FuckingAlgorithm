public class Solution {
    public int PivotIndex(int[] nums) {
        if (nums == null || nums.Length < 3) return -1;

        int leftSum = 0, rightSum = 0, sum = nums.Sum();
        for (int i = 0, l = nums.Length; i < l; i++) {
            if (leftSum == sum - leftSum - nums[i])
                return i;
            leftSum += nums[i];
        }

        return -1;
    }
}