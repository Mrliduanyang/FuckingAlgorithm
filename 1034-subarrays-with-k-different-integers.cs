public class Solution {
    public int SubarraysWithKDistinct(int[] A, int K) {
                int Helper(int[] A, int K) {
                    int len = A.Length;
                    int[] freq = new int[len + 1];
                    int left = 0;
                    int right = 0;
                    int count = 0;
                    int res = 0;
                    while (right < len) {
                        if (freq[A[right]] == 0) {
                            count++;
                        }
                        freq[A[right]]++;
                        right++;

                        while (count > K) {
                            freq[A[left]]--;
                            if (freq[A[left]] == 0) {
                                count--;
                            }
                            left++;
                        }
                        res += right - left;
                    }
                    return res;
                }
                return Helper(A, K) - Helper(A, K - 1);
    }
}