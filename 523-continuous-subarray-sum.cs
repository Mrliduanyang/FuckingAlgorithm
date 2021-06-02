using System.Collections.Generic;

public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        var n = nums.Length;
        if (n < 2) return false;
        var remainder = 0;
        var dict = new Dictionary<int, int>();
        dict[0] = -1;
        for (var i = 0; i < n; ++i) {
            remainder = (remainder + nums[i]) % k;
            if (dict.ContainsKey(remainder)) {
                var preIdx = dict[remainder];
                if (i - preIdx >= 2) {
                    return true;
                }
            }
            else {
                dict[remainder] = i;
            }
        }

        return false;
    }
}