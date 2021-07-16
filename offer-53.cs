public class Solution {
    public int Search(int[] nums, int target) {
        var leftIdx = BinarySearch(nums, target, true);
        var rightIdx = BinarySearch(nums, target, false) - 1;
        if (leftIdx <= rightIdx && rightIdx < nums.Length && nums[leftIdx] == target && nums[rightIdx] == target) {
            return rightIdx - leftIdx + 1;
        }

        return 0;
    }

    public int BinarySearch(int[] nums, int target, bool lower) {
        int left = 0, right = nums.Length, ans = nums.Length;
        while (left < right) {
            var mid = left + (right - left) / 2;
            if (nums[mid] > target || (lower && nums[mid] >= target)) {
                right = mid;
                ans = mid;
            }
            else {
                left = mid + 1;
            }
        }

        return ans;
    }
}