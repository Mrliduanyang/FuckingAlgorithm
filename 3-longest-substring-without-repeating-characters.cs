using System;
using System.Collections.Generic;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var window = new Dictionary<char, int>();
        int left = 0, right = 0;
        var res = 0;
        while (right < s.Length) {
            var ch = s[right];
            right++;
            window[ch] = window.GetValueOrDefault(ch, 0) + 1;
            while (window[ch] > 1) {
                var tmp = s[left];
                left++;
                window[tmp]--;
            }

            res = Math.Max(res, right - left);
        }

        return res;
    }
}