public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        if (nums.Length == 0) return 0;
        var ans = 0;
        int left = 0, right = 0;
        while (left < nums.Length && right < nums.Length)
            if (nums[left] != 1) {
                left++;
            }
            else {
                right = left;
                while (right < nums.Length && nums[right] == 1) right++;
                ans = Math.Max(ans, right - left);
                left = right;
            }

        return ans;
    }
}