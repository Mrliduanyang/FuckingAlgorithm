public class Solution {
    public bool IsMonotonic(int[] A) {
        bool inc = true, dec = true;
        var n = A.Length;
        for (var i = 0; i < n - 1; ++i) {
            if (A[i] > A[i + 1]) inc = false;
            if (A[i] < A[i + 1]) dec = false;
        }

        return inc || dec;
    }
}