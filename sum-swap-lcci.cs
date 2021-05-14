using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] FindSwapValues(int[] array1, int[] array2) {
        var s1 = new HashSet<int>(array1);
        var s2 = new HashSet<int>(array2);
        var diff = (float) (array1.Sum() - array2.Sum()) / 2;
        if (diff == 0 || (diff * 10) % 10 == 5) return Array.Empty<int>();
        var intDiff = Convert.ToInt32(diff);
        foreach (var num in s1) {
            if (s2.Contains(num - intDiff)) {
                return new[] {num, num - intDiff};
            }
        }

        return Array.Empty<int>();
    }
}