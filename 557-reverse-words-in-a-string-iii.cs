public class Solution {
    public string ReverseWords(string s) {
        var res = new StringBuilder();
        var len = s.Length;
        var i = 0;
        while (i < len) {
            var start = i;
            while (i < len && s[i] != ' ') i++;
            for (var p = start; p < i; p++) res.Append(s[start + i - 1 - p]);
            while (i < len && s[i] == ' ') {
                i++;
                res.Append(' ');
            }
        }

        return res.ToString();
    }
}