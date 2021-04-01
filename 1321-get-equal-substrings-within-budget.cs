public class Solution {
    public int EqualSubstring(string s, string t, int maxCost) {
        var window = 0;
        var res = 0;
        int left = 0, right = 0;
        var diff = new int[s.Length];
        for (var i = 0; i < s.Length; i++) diff[i] = Math.Abs(s[i] - t[i]);
        while (right < s.Length) {
            var ch = s[right];
            window += diff[right];
            right++;
            while (window > maxCost) {
                window -= diff[left];
                left++;
            }

            res = Math.Max(res, right - left);
        }

        return res;
    }
}