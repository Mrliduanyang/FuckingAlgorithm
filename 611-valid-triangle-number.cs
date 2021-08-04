using System;

public class Solution {
    public int TriangleNumber(int[] nums) {
        Array.Sort(nums);
        var res = 0;
        for (var i = 0; i < nums.Length; ++i) {
            for (var j = i + 1; j < nums.Length; ++j) {
                int left = j + 1, right = nums.Length, k = j;
                while (left < right) {
                    var mid = (left + right) / 2;
                    if (nums[mid] < nums[i] + nums[j]) {
                        k = mid;
                        left = mid + 1;
                    } else {
                        right = mid;
                    }
                }
                res += k - j;
            }
        }
        return res;
    }
}