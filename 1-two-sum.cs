using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        var n = nums.Length;
        for (var i = 0; i < n; i++)
            if (map.ContainsKey(nums[i]))
                map[nums[i]] = i;
            else
                map.Add(nums[i], i);
        for (var i = 0; i < n; i++) {
            var other = target - nums[i];
            if (map.ContainsKey(other) && map[other] != i) return new[] {i, map[other]};
        }

        return new[] {-1, -1};
    }
}