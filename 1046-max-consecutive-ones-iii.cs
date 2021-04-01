public class Solution {
    public int LongestOnes(int[] A, int K) {
        int left = 0, right = 0;
        var res = 0;
        var zeroCount = 0;
        while (right < A.Length) {
            if (A[right] == 0) zeroCount++;
            right++;
            while (zeroCount > K) {
                if (A[left] == 0) zeroCount--;
                left++;
            }

            res = Math.Max(res, right - left);
        }

        return res;
    }
}