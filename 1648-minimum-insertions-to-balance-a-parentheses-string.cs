public class Solution {
    public int MinInsertions(string s) {
        int res = 0, need = 0;

        foreach (var c in s) {
            if (c == '(') {
                need += 2;
                if (need % 2 == 1) {
                    res++;
                    need--;
                }
            }

            if (c == ')') {
                need--;
                if (need == -1) {
                    res++;
                    need = 1;
                }
            }
        }

        return res + need;
    }
}