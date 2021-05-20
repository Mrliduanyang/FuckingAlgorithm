using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    private int[] tree;

    private int[] nums;

    private void Init(int length) {
        tree = new int[length];
        Array.Fill(tree, 0);
    }

    private int LowBit(int x) {
        return x & (-x);
    }

    private void Update(int idx) {
        while (idx < tree.Length) {
            tree[idx] += 1;
            idx += LowBit(idx);
        }
    }

    private int Query(int idx) {
        int ret = 0;
        while (idx > 0) {
            ret += tree[idx];
            idx -= LowBit(idx);
        }

        return ret;
    }

    private void Discretization(int[] nums) {
        var hashSet = new HashSet<int>(nums);
        this.nums = hashSet.ToArray();
        Array.Sort(this.nums);
    }

    private int GetId(int x) {
        return Array.BinarySearch(nums, x) + 1;
    }

    public int ReversePairs(int[] nums) {
        var res = 0;

        Discretization(nums);

        Init(nums.Length + 5);

        for (int i = nums.Length - 1; i >= 0; --i) {
            var id = GetId(nums[i]);
            res += (Query(id - 1));
            Update(id);
        }

        return res;
    }
}