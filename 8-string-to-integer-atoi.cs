public class Solution {
    public int MyAtoi(string s) {
        int sign = 1, cur = 0, i = 0;
        while (i < s.Length && s[i] == ' ') ++i;

        if (i < s.Length && (s[i] == '+' || s[i] == '-')) sign = 1 - 2 * (s[i++] == '-' ? 1 : 0);
        while (i < s.Length && s[i] >= '0' && s[i] <= '9') {
            if (cur > int.MaxValue / 10 || cur == int.MaxValue / 10 && s[i] - '0' > int.MaxValue % 10)
                return sign == 1 ? int.MaxValue : int.MinValue;
            cur = cur * 10 + (s[i++] - '0');
        }

        return cur * sign;
    }
}