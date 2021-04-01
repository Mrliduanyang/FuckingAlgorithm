public class Solution {
    public bool CanMeasureWater(int x, int y, int z) {
        int gcd(int x, int y) {
            var remainder = x % y;
            while (remainder != 0) {
                x = y;
                y = remainder;
                remainder = x % y;
            }

            return y;
        }

        // 最后请用以上水壶中的一或两个来盛放取得的z升水。
        if (x + y < z) return false;
        if (x == 0 || y == 0) return z == 0 || x + y == z;
        return z % gcd(x, y) == 0;
    }
}