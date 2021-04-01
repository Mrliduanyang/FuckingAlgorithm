public class Solution {
            public int MinSteps(int n) {
                int ans = 0, d = 2;
                while (n > 1) {
                    while (n % d == 0) {
                        ans += d;
                        n /= d;
                    }
                    d++;
                }
                return ans;
            }
}