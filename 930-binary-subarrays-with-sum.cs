using System.Collections.Generic;

public class Solution {
    public int NumSubarraysWithSum(int[] nums, int goal) {
        var dict = new Dictionary<int, int>();
        var sum = 0;
        var res = 0;
        foreach (var num in nums) {
            dict[sum] = dict.GetValueOrDefault(sum, 0) + 1;
            sum += num;
            dict.TryGetValue(sum - goal, out var val);
            res += val;
        }

        return res;
    }
}