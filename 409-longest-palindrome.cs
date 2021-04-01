public class Solution {
    public int LongestPalindrome(string s) {
        var dict = new Dictionary<char, int>();
        var length = s.Length;
        foreach (var ch in s) dict[ch] = dict.GetValueOrDefault(ch, 0) + 1;

        var ans = 0;
        foreach (var (key, val) in dict) {
            ans += val / 2 * 2;
            if (val % 2 == 1 && ans % 2 == 0) ans++;
        }

        return ans;
    }
}