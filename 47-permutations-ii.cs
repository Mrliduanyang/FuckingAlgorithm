using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public List<IList<int>> PermuteUnique(int[] nums) {
        var res = new List<IList<int>>();
        var path = new List<int>();
        var vis = new bool[nums.Length];
        Array.Sort(nums);

        void Helper(int idx) {
            if (idx == nums.Length) {
                res.Add(path.ToList());
                return;
            }

            for (var i = 0; i < nums.Length; ++i) {
                if (vis[i] || i > 0 && nums[i] == nums[i - 1] && !vis[i - 1]) continue;
                path.Add(nums[i]);
                vis[i] = true;
                Helper(idx + 1);
                vis[i] = false;
                path.RemoveAt(idx);
            }
        }

        Helper(0);
        return res;
    }
}