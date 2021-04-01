public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
                var res = new List<int>();
                int left = 0, right = 0;
                var need = new Dictionary<char, int>();
                var window = new Dictionary<char, int>();
                int valid = 0;
                foreach (var ch in p) {
                    need[ch] = need.GetValueOrDefault(ch, 0) + 1;
                }
                while (right < s.Length) {
                    var ch = s[right];
                    right++;
                    if (need.ContainsKey(ch)) {
                        window[ch] = window.GetValueOrDefault(ch, 0) + 1;
                        if (window[ch] == need[ch]) {
                            valid++;
                        }
                    }
                    while (right - left >= p.Length) {
                        if (valid == need.Keys.Count) {
                            res.Add(left);
                        }
                        var delCh = s[left];
                        left++;
                        if (need.ContainsKey(delCh)) {
                            if (window[delCh] == need[delCh]) {
                                valid--;
                            }
                            window[delCh]--;
                        }
                    }
                }
                return res;
    }
}