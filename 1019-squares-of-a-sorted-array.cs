public class Solution {
    public int[] SortedSquares(int[] A) {
        var n = A.Length;
        var ans = new int[n];
        for (int i = 0, j = n - 1, pos = n - 1; i <= j;) {
            if (A[i] * A[i] > A[j] * A[j]) {
                ans[pos] = A[i] * A[i];
                ++i;
            }
            else {
                ans[pos] = A[j] * A[j];
                --j;
            }

            --pos;
        }

        return ans;
    }
}