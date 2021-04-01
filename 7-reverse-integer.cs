public class Solution {
    public int Reverse(int x) {
                int res = 0;
                while (x != 0) {
                    int cur = x % 10;
                    x /= 10;
                    if (res > int.MaxValue / 10 || (res == int.MaxValue / 10 && cur > int.MaxValue % 10)) return 0;

                    if (res < int.MinValue / 10 || (res == int.MinValue / 10 && cur < int.MinValue % 10)) return 0;
                    res = res * 10 + cur;
                }
                return res;
    }
}