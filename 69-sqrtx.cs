public class Solution {
    public int MySqrt(int x) {
        if (x == 0) return 0;
        var ans = (int) Math.Exp(0.5 * Math.Log(x));
        return (long) (ans + 1) * (ans + 1) <= x ? ans + 1 : ans;
    }
}