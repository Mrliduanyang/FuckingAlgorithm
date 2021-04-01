public class Solution {
    public string SortString(string s) {
        var dict = new int[26];
        foreach (var ch in s) dict[ch - 'a']++;
        var res = new StringBuilder();
        while (res.Length != s.Length) {
            for (var i = 0; i < 26; i++)
                if (dict[i] > 0) {
                    res.Append((char) (i + 'a'));
                    dict[i]--;
                }

            for (var i = 25; i >= 0; i--)
                if (dict[i] > 0) {
                    res.Append((char) (i + 'a'));
                    dict[i]--;
                }
        }

        return res.ToString();
    }
}