public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length;
        while (l < r) {
            var mid = l + (r - l) / 2;
            if (nums[mid] == target) return mid;
            if (nums[0] <= nums[mid]) {
                if (nums[0] <= target && target < nums[mid])
                    r = mid;
                else
                    l = mid + 1;
            }
            else {
                if (nums[mid] < target && target <= nums[n - 1])
                    l = mid + 1;
                else
                    r = mid;
            }
        }

        return -1;
    }
}