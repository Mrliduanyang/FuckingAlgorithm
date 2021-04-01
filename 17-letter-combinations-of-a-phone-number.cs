public class Solution {
    public IList<string> LetterCombinations(string digits) {
var numCharMap = new Dictionary<char, char[]>() { { '2', new char[] { 'a', 'b', 'c' } }, { '3', new char[] { 'd', 'e', 'f' } }, { '4', new char[] { 'g', 'h', 'i' } }, { '5', new char[] { 'j', 'k', 'l' } }, { '6', new char[] { 'm', 'n', 'o' } }, { '7', new char[] { 'p', 'q', 'r', 's' } }, { '8', new char[] { 't', 'u', 'v' } }, { '9', new char[] { 'w', 'x', 'y', 'z' } },
                    };

                var path = new List<char>();
                var res = new List<string>();

                if (digits.Length == 0) {
                    return res;
                }
                Helper(digits ,0, numCharMap, path, res);
                return res;
    }
                    void Helper(string digits, int curr, Dictionary<char, char[]> numCharMap, List<char> path, List<string> res) {
                    if (path.Count == digits.Length) {
                        res.Add(string.Join("", path));
                        return;
                    }
                    foreach (var ch in numCharMap[digits[curr]]) {
                        path.Add(ch);
                        Helper(digits, curr + 1, numCharMap ,path, res);
                        path.RemoveAt(path.Count - 1);
                    }
                }
}