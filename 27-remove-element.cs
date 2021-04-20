public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var left = 0;
        var right = nums.Length;
        while (left < right) {
            if (nums[left] == val) {
                nums[left] = nums[right - 1];
                right--;
            }
            else {
                left++;
            }
        }

        return left;
    }
}