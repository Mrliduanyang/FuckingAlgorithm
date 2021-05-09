using System;
using System.Linq;

public class Solution {
    public int MinDays(int[] bloomDay, int m, int k) {
        if (m > bloomDay.Length / k) {
            return -1;
        }

        bool Check(int days) {
            var bouquets = 0;
            var flowers = 0;
            var length = bloomDay.Length;
            for (var i = 0; i < length && bouquets < m; i++) {
                if (bloomDay[i] <= days) {
                    flowers++;
                    if (flowers == k) {
                        bouquets++;
                        flowers = 0;
                    }
                }
                else {
                    flowers = 0;
                }
            }

            return bouquets >= m;
        }

        int low = bloomDay.Min(), high = bloomDay.Max();
        while (low < high) {
            var days = low + (high - low) / 2;
            if (Check(days)) {
                high = days;
            }
            else {
                low = days + 1;
            }
        }

        return low;
    }
}