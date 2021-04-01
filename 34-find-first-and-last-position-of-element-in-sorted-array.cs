public class Solution {
    public int[] SearchRange(int[] nums, int target) {
                if (nums.Length == 0) {
                    return new int[] { -1, -1 };
                }
                int left = 0, right = nums.Length;
                while (left < right) {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] == target) {
                        int l = mid, r = mid;
                        while (l >= 0 && nums[l] == target) {
                            l--;
                        }
                        while (r < nums.Length && nums[r] == target) {
                            r++;
                        }
                        return new int[] { l + 1, r - 1 };
                    } else if (nums[mid] < target) {
                        left = mid + 1;
                    } else {
                        right = mid;
                    }
                }
                return new int[] { -1, -1 };
    }
}