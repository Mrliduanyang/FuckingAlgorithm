using System;
using System.Collections.Generic;

public class Solution {
    public List<List<int>> PairSums(int[] nums, int target) {
        var res = new List<List<int>>();
        Array.Sort(nums);
        int i = 0, j = nums.Length - 1;
        while (i < j) {
            var sum = nums[i] + nums[j];
            if (sum == target) {
                res.Add(new List<int> {nums[i], nums[j]});
                ++i;
                --j;
            }
            else if (sum < target) {
                ++i;
            }
            else {
                --j;
            }
        }

        return res;
    }
}