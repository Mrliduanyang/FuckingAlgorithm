public class Solution {
    public IList<string> LetterCasePermutation(string S) {
        var n = S.Length;
        var path = new StringBuilder();
        var res = new List<string>();

        void Helper(int idx) {
            if (path.Length == n) {
                res.Add(path.ToString());
                return;
            }

            ;
            var ch = S[idx];
            if (char.IsLetter(ch)) {
                path.Append(char.ToLower(ch));
                Helper(idx + 1);
                path.Remove(idx, 1);

                path.Append(char.ToUpper(ch));
                Helper(idx + 1);
                path.Remove(idx, 1);
            }
            else {
                path.Append(ch);
                Helper(idx + 1);
                path.Remove(idx, 1);
            }
        }

        Helper(0);
        return res;
    }
}