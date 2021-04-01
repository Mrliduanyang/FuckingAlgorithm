public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        var n = s.Length;
        if (n * k == 0) return 0;
        int left = 0, right = 0;
        var dict = new Dictionary<char, int>();
        var res = 1;
        while (right < n) {
            dict[s[right]] = right++;
            if (dict.Count == k + 1) {
                int del_idx = dict.Values.Min();
                dict.Remove(s[del_idx]);
                left = del_idx + 1;
            }

            res = Math.Max(res, right - left);
        }

        return res;
    }
}