public class Solution {
    public int CountSegments(string s) {
                int res = 0;
                for (int i = 0; i < s.Length; i++) {
                    if ((i == 0 || s[i - 1] == ' ') && s[i] != ' ') {
                        res++;
                    }
                }
                return res;
    }
}