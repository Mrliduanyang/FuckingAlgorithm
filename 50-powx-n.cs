public class Solution {
    public double MyPow(double x, int n) {
        double QuickMul(double x, long N) {
            var ans = 1.0;
            // 贡献的初始值为 x
            var x_contribute = x;
            // 在对 N 进行二进制拆分的同时计算答案
            while (N > 0) {
                if (N % 2 == 1) // 如果 N 二进制表示的最低位为 1，那么需要计入贡献
                    ans *= x_contribute;
                // 将贡献不断地平方
                x_contribute *= x_contribute;
                // 舍弃 N 二进制表示的最低位，这样我们每次只要判断最低位即可
                N /= 2;
            }

            return ans;
        }

        long N = n;
        return N >= 0 ? QuickMul(x, N) : 1.0 / QuickMul(x, -N);
    }
}