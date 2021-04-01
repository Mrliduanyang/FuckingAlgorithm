public class Solution {
    public string MinWindow(string s, string t) {
                var need = new Dictionary<char, int>();
                var window = new Dictionary<char, int>();
                foreach (var ch in t) {
                    need[ch] = need.GetValueOrDefault(ch, 0) + 1;
                }
                int left = 0, right = 0, valid = 0;
                int start = 0, len = int.MaxValue;
                while (right < s.Length) {
                    var ch = s[right];
                    ++right;
                    if (need.ContainsKey(ch)) {
                        window[ch] = window.GetValueOrDefault(ch, 0) + 1;
                        if (window[ch] == need[ch]) valid++;
                    }
                    while (valid == need.Count) {
                        if ((right - left) < len) {
                            start = left;
                            len = right - left;
                        }
                        var leftCh = s[left];
                        ++left;
                        if (need.ContainsKey(leftCh)) {
                            if (window[leftCh] == need[leftCh]) --valid;
                            --window[leftCh];
                        }
                    }
                }
                return len == int.MaxValue ? "" :s.Substring(start, len);
    }
}