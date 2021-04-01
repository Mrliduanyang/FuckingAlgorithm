public class Solution {
    public string ShiftingLetters(string S, int[] shifts) {
        var res = new char[S.Length];
        var times = 0;
        for (var i = shifts.Length - 1; i >= 0; i--) {
            times = (times + shifts[i]) % 26;
            var idx = S[i] - 'a';
            res[i] = (char) ((idx + times) % 26 + 97);
        }

        return new string(res);
    }
}