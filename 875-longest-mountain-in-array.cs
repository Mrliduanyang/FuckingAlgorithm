public class Solution {
    public int LongestMountain(int[] A) {
        var n = A.Length;
        if (n == 0) return 0;
        var left = new int[n];
        for (var i = 1; i < n; ++i) left[i] = A[i - 1] < A[i] ? left[i - 1] + 1 : 0;
        var right = new int[n];
        for (var i = n - 2; i >= 0; --i) right[i] = A[i + 1] < A[i] ? right[i + 1] + 1 : 0;

        var ans = 0;
        for (var i = 0; i < n; ++i)
            if (left[i] > 0 && right[i] > 0)
                ans = Math.Max(ans, left[i] + right[i] + 1);
        return ans;
    }
}