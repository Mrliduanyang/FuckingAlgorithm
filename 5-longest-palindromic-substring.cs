using System;
using System.Linq;

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

    public string LongestPalindrome_Manahcer(string s) {
        int ExpandAroundCenter(int left, int right) {
            while (left >= 0 && right < s.Length && s[left] == s[right]) {
                --left;
                ++right;
            }

            return (right - left - 2) / 2;
        }

        s = $"#{string.Join('#', s.ToArray())}";

        int start = 0, end = -1;
        int j = -1, right = -1;
        var armLen = new int[s.Length];

        for (var i = 0; i < s.Length; ++i) {
            int curArmLen;
            if (right >= i) {
                var symI = 2 * j - i;
                var minArmLen = Math.Min(right - i, armLen[symI]);
                curArmLen = ExpandAroundCenter(i - minArmLen, i + minArmLen);
            }
            else {
                curArmLen = ExpandAroundCenter(i, i);
            }

            armLen[i] = curArmLen;

            if (i + curArmLen > right) {
                j = i;
                right = i + curArmLen;
            }

            if (2 * curArmLen + 1 > end - start) {
                start = i - curArmLen;
                end = i + curArmLen;
            }
        }

        return string.Join("", s[start..(end + 1)].Where(x => x != '#'));
    }
}