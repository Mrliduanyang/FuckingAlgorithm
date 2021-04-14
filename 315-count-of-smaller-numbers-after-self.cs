using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public List<int> CountSmaller(int[] nums) {
        var a = (int[]) nums.Clone();
        var hashSet = new HashSet<int>(a);
        a = hashSet.ToArray();
        Array.Sort(a);
        
        var c = new int[a.Length + 5];

        int LowBit(int x) {
            return x & (-x);
        }

        void Update(int idx) {
            while (idx < c.Length) {
                c[idx] += 1;
                idx += LowBit(idx);
            }
        }

        int Query(int idx) {
            int ret = 0;
            while (idx > 0) {
                ret += c[idx];
                idx -= LowBit(idx);
            }

            return ret;
        }

        int GetId(int x) {
            return Array.BinarySearch(a, x) + 1;
        }

        var res = new List<int>();
        for (int i = nums.Length - 1; i >= 0; --i) {
            var id = GetId(nums[i]);
            res.Add(Query(id - 1));
            Update(id);
        }

        res.Reverse();

        return res;
    }
}