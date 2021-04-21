using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    private int[] c;

    private int[] a;

    private void Init(int length) {
        c = new int[length];
        Array.Fill(c, 0);
    }

    private int LowBit(int x) {
        return x & (-x);
    }

    private void Update(int idx) {
        while (idx < c.Length) {
            c[idx] += 1;
            idx += LowBit(idx);
        }
    }

    private int Query(int idx) {
        int ret = 0;
        while (idx > 0) {
            ret += c[idx];
            idx -= LowBit(idx);
        }

        return ret;
    }

    private void Discretization(int[] nums) {
        a = (int[]) nums.Clone();
        var hashSet = new HashSet<int>(a);
        a = hashSet.ToArray();
        Array.Sort(a);
    }

    private int GetId(int x) {
        return Array.BinarySearch(a, x) + 1;
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