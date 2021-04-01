public class Solution {
    public int CountSegments(string s) {
        var res = 0;
        for (var i = 0; i < s.Length; i++)
            if ((i == 0 || s[i - 1] == ' ') && s[i] != ' ')
                res++;
        return res;
    }
}