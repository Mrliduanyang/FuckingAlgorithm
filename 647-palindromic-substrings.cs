public class Solution {
    public int CountSubstrings(string s) {
        int n = s.Length, res = 0;
        for (var i = 0; i < 2 * n - 1; ++i) {
            int l = i / 2, r = i / 2 + i % 2;
            while (l >= 0 && r < n && s[l] == s[r]) {
                --l;
                ++r;
                ++res;
            }
        }

        return res;
    }
}