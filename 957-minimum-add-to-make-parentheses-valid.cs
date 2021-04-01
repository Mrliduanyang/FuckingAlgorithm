public class Solution {
    public int MinAddToMakeValid(string S) {
        var res = 0;
        var need = 0;
        foreach (var c in S) {
            if (c == '(') need++;
            if (c == ')') {
                need--;
                if (need == -1) {
                    res++;
                    need = 0;
                }
            }
        }

        return res + need;
    }
}