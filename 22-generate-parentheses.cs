public class Solution {
    public IList<string> GenerateParenthesis(int n) {
                var res = new List<string>();
                var path = new List<char>();

                Helper(0, 0, n, path, res);
                return res;
    }
                    void Helper(int close, int open, int max, List<char> path, List<string> res) {
                    if (path.Count == max * 2) {
                        res.Add(string.Join("", path));
                        return;
                    }
                    if (open < max) {
                        path.Add('(');
                        Helper(close, open + 1, max, path, res);
                        path.RemoveAt(path.Count - 1);
                    }
                    if (close < open) {
                        path.Add(')');
                        Helper(close + 1, open, max, path, res);
                        path.RemoveAt(path.Count - 1);
                    }
                }
}