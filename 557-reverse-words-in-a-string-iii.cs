public class Solution {
    public string ReverseWords(string s) {
               var res = new StringBuilder();
                int len = s.Length;
                int i = 0;
                while (i < len) {
                    int start = i;
                    while (i < len && s[i] != ' ') {
                        i++;
                    }
                    for (int p = start; p < i; p++) {
                        res.Append(s[start + i - 1 - p]);
                    }
                    while (i < len && s[i] == ' ') {
                        i++;
                        res.Append(' ');
                    }
                }
                return res.ToString();
    }
}