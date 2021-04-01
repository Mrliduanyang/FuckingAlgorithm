using System.Collections.Generic;
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            if (map.ContainsKey(nums[i])) {
                map[nums[i]] = i;
            } else {
                map.Add(nums[i], i);
            }
        }
        for (int i = 0; i < n; i++) {
            int other = target - nums[i];
            if (map.ContainsKey(other) && map[other] != i) {
                return new int[] { i, map[other] };
            }
        }
        return new int[] {-1, -1 };
    }
}