using System;
using System.Linq;

public class Solution {
    public bool Search(int[] nums, int target) {
        int l = 0, r = nums.Length;
        if (r == 1) {
            return nums[0] == target;
        }

        while (l < r) {
            var mid = l + (r - l) / 2;
            if (nums[mid] == target) return true;

            if (nums[l] == nums[mid]) {
                ++l;
            }
            else if (nums[l] < nums[mid]) {
                if (nums[l] <= target && nums[mid] > target) {
                    r = mid;
                }
                else {
                    l = mid + 1;
                }
            }
            else {
                if (nums[mid] < target && target <= nums.Last()) {
                    l = mid + 1;
                }
                else {
                    r = mid;
                }
            }
        }

        return false;
    }
}