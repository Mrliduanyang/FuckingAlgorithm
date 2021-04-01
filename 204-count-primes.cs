public class Solution {
            public int CountPrimes(int n) {
                int[] isPrime = new int[n];
                Array.Fill(isPrime, 1);
                int ans = 0;
                for (int i = 2; i < n; ++i) {
                    if (isPrime[i] == 1) {
                        ans += 1;
                        if ((long) i * i < n) {
                            for (int j = i * i; j < n; j += i) {
                                isPrime[j] = 0;
                            }
                        }
                    }
                }
                return ans;
            }
}