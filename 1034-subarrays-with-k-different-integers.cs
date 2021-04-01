public class Solution {
    public int SubarraysWithKDistinct(int[] A, int K) {
        int Helper(int[] A, int K) {
            var len = A.Length;
            var freq = new int[len + 1];
            var left = 0;
            var right = 0;
            var count = 0;
            var res = 0;
            while (right < len) {
                if (freq[A[right]] == 0) count++;
                freq[A[right]]++;
                right++;

                while (count > K) {
                    freq[A[left]]--;
                    if (freq[A[left]] == 0) count--;
                    left++;
                }

                res += right - left;
            }

            return res;
        }

        return Helper(A, K) - Helper(A, K - 1);
    }
}