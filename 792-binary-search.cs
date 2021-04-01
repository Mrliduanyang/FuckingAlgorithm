public class Solution {
    public int Search(int[] nums, int target) {
                int left = 0, right = nums.Length;
                while (left < right) {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] == target) {
                        return mid;
                    } else if (nums[mid] < target) {
                        left = mid + 1;
                    } else {
                        right = mid;
                    }
                }
                return -1;
    }
}