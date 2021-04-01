public class Solution {
    public int LengthOfLongestSubstring(string s) {
var window = new Dictionary<char, int>();
                int left = 0, right = 0;
                int res = 0;
                while (right < s.Length) {
                    var ch = s[right];
                    right++;
                    if (window.ContainsKey(ch)) {
                        window[ch]++;
                    } else {
                        window[ch] = 1;
                    }
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