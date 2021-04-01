public class Solution {
    public string SortString(string s) {
var dict = new int[26];
                foreach (var ch in s) {
                    dict[ch - 'a']++;
                }
                var res = new StringBuilder();
                while (res.Length != s.Length) {
                    for (int i = 0; i < 26; i++) {
                        if (dict[i] > 0) {
                            res.Append((char) (i + 'a'));
                            dict[i]--;
                        }
                    }
                    for (int i = 25; i >= 0; i--) {
                        if (dict[i] > 0) {
                            res.Append((char) (i + 'a'));
                            dict[i]--;
                        }
                    }
                }
                return res.ToString();
    }
}