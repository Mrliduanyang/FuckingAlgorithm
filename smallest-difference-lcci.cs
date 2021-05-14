using System;

public class Solution {
    public int SmallestDifference(int[] a, int[] b) {
        Array.Sort(a);
        Array.Sort(b);
        var min = long.MaxValue;
        int i = 0, j = 0;
        while (i < a.Length && j < b.Length) {
            long diff = b[j] - a[i];
            if (diff > 0) {
                min = Math.Min(min, Math.Abs(diff));
                i++;
            }
            else if (diff < 0) {
                min = Math.Min(min, Math.Abs(diff));
                j++;
            }
            else {
                return 0;
            }
        }

        return (int) min;
    }
}