using System;

public class Solution {
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr) {
        var n = arr.Length;
        Array.Sort(arr);
        arr[0] = 1;
        for (var i = 1; i < n; ++i) {
            arr[i] = Math.Min(arr[i], arr[i - 1] + 1);
        }
        return arr[n - 1];
    }
}