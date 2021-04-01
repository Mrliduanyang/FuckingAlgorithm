public class Solution {
    public string LongestPalindrome(string s) {
        var res = "";
        for (var i = 0; i < s.Length; i++) {
            // 以s[i]为中心的最长回文子串
            var s1 = Palindrome(s, i, i);
            // 以s[i]和s[i+1]为中心的最长回文子串
            var s2 = Palindrome(s, i, i + 1);
            res = res.Length > s1.Length ? res : s1;
            res = res.Length > s2.Length ? res : s2;
        }

        return res;
    }

    public string Palindrome(string s, int l, int r) {
        while (l >= 0 && r < s.Length && s[l] == s[r]) {
            l--;
            r++;
        }

        return s.Substring(l + 1, r - l - 1);
    }
}