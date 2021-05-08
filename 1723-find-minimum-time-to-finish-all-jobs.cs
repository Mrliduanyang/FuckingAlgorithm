using System;

public class Solution {
    public int MinimumTimeRequired(int[] jobs, int k) {
        var res = int.MaxValue;
        var n = jobs.Length;
        var sum = new int[k];

        void Helper(int idx, int used, int max) {
            if (max > res) return;
            if (idx == n) {
                res = max;
                return;
            }

            if (used < k) {
                sum[used] = jobs[idx];
                Helper(idx + 1, used + 1, Math.Max(sum[used], max));
                sum[used] = 0;
            }

            for (var i = 0; i < used; i++) {
                sum[i] += jobs[idx];
                Helper(idx + 1, used, Math.Max(sum[i], max));
                sum[i] -= jobs[idx];
            }
        }

        Helper(0, 0, 0);
        return res;
    }
}