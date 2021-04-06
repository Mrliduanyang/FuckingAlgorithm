public class Solution {
    public bool Search(int[] nums, int target) {
        if (nums == null || nums.Length == 0) return false;
        var left = 0;
        var right = nums.Length - 1;
        int mid;
        while (left <= right) {
            mid = left + (right - left) / 2;
            if (nums[mid] == target) return true;

            if (nums[left] == nums[mid]) {
                ++left;
                continue;
            }

            if (nums[left] < nums[mid]) {
                if (nums[left] <= target && nums[mid] > target) {
                    right = mid - 1;
                }
                else {
                    left = mid + 1;
                }
            }
            else {
                if (nums[mid] < target && target <= nums[right]) {
                    left = mid + 1;
                }
                else {
                    right = mid - 1;
                }
            }
        }

        return false;
    }
}