using System;
using System.Collections.Generic;

public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        int GetId(int i, int w) {
            if (i >= 0)
                return i / w;
            return (i + 1) / w - 1;
        }

        var dict = new Dictionary<long, long>();
        var bulk = t + 1;
        for (var i = 0; i < nums.Length; i++) {
            var id = GetId(nums[i], bulk);
            if (dict.ContainsKey(id)) {
                return true;
            }

            if (dict.ContainsKey(id - 1) && Math.Abs(nums[i] - dict[id - 1]) < bulk) {
                return true;
            }

            if (dict.ContainsKey(id + 1) && Math.Abs(nums[i] - dict[id + 1]) < bulk) {
                return true;
            }

            dict[id] = (long) nums[i];
            if (i >= k) {
                dict.Remove(GetId(nums[i - k], bulk));
            }
        }

        return false;
    }
}