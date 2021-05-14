using System.Collections.Generic;

public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var res = new List<string>();
        var path = new List<char>();

        void Helper(int close, int open) {
            if (path.Count == n * 2) {
                res.Add(string.Join("", path));
                return;
            }

            if (open < n) {
                path.Add('(');
                Helper(close, open + 1);
                path.RemoveAt(path.Count - 1);
            }

            if (close < open) {
                path.Add(')');
                Helper(close + 1, open);
                path.RemoveAt(path.Count - 1);
            }
        }

        Helper(0, 0);
        return res;
    }
}