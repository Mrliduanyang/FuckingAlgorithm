using System;

public class Solution {
    public int MinAbsoluteSumDiff(int[] nums1, int[] nums2) {
        const int MOD = 1000000007;
        var rec = (int[]) nums1.Clone();
        var sum = 0;
        var maxn = 0;


        Array.Sort(rec);
        for (var i = 0; i < nums1.Length; i++) {
            var diff = Math.Abs(nums1[i] - nums2[i]);
            sum = (sum + diff) % MOD;
            var j = Array.BinarySearch(rec, nums2[i]);
            if (j < 0) j = -(j + 1);
            if (j < nums1.Length) {
                maxn = Math.Max(maxn, diff - (rec[j] - nums2[i]));
            }

            if (j > 0) {
                maxn = Math.Max(maxn, diff - (nums2[i] - rec[j - 1]));
            }
        }

        return (sum - maxn + MOD) % MOD;
    }
}