public class Solution {
    public bool IsPalindrome(int x) {
        if (x < 0) return false;
        var res = 0;
        var oldX = x;
        while (x != 0) {
            var cur = x % 10;
            x /= 10;
            if (res > int.MaxValue / 10) return false;
            res = res * 10 + cur;
        }

        return oldX == res;
    }
}