public class Solution {
    public int RotatedDigits(int N) {
                bool Helper(int n, bool flag) {
                    if (n == 0) return flag;

                    int d = n % 10;
                    if (d == 3 || d == 4 || d == 7) return false;
                    if (d == 0 || d == 1 || d == 8) return Helper(n / 10, flag);
                    return Helper(n / 10, true);
                }
                int ans = 0;
                for (int n = 1; n <= N; ++n)
                    if (Helper(n, false)) ans++;
                return ans;
    }
}