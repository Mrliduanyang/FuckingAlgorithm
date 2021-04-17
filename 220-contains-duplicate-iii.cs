using System;
using System.Collections.Generic;

public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        if (nums.Length == 0)
            return false;

        if (t < 0 || k <= 0)
            return false;

        int bulk = t + 1;
        Dictionary<long, long> dict = new Dictionary<long, long>();
        for (int i = 0; i < nums.Length; i++) {
            if (i > k) {
                dict.Remove(getID(nums[i - k - 1], bulk));
                Console.WriteLine("remove:" + (i - k - 1));
            }

            int id = getID(nums[i], bulk);
            if (dict.ContainsKey(id))
                return true;
            dict[id] = nums[i];
            if (dict.ContainsKey(id - 1) && Math.Abs(dict[id - 1] - dict[id]) <= t)
                return true;
            if (dict.ContainsKey(id + 1) && Math.Abs(dict[id + 1] - dict[id]) <= t)
                return true;
        }

        return false;
    }

    int getID(int i, int w) {
        if (i >= 0)
            return i / w;
        return (i + 1) / w - 1;
    }
}