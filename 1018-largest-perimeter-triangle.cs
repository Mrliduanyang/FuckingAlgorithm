public class Solution {
    public int LargestPerimeter(int[] A) {
        Array.Sort(A);
        for (var i = A.Length - 1; i >= 2; i--)
            if (A[i] < A[i - 1] + A[i - 2])
                return A[i] + A[i - 1] + A[i - 2];
        return 0;
    }
}