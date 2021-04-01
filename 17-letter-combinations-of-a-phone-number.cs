public class Solution {
    public IList<string> LetterCombinations(string digits) {
        var numCharMap = new Dictionary<char, char[]> {
            {'2', new[] {'a', 'b', 'c'}}, {'3', new[] {'d', 'e', 'f'}}, {'4', new[] {'g', 'h', 'i'}},
            {'5', new[] {'j', 'k', 'l'}}, {'6', new[] {'m', 'n', 'o'}}, {'7', new[] {'p', 'q', 'r', 's'}},
            {'8', new[] {'t', 'u', 'v'}}, {'9', new[] {'w', 'x', 'y', 'z'}}
        };

        var path = new List<char>();
        var res = new List<string>();

        if (digits.Length == 0) return res;
        Helper(digits, 0, numCharMap, path, res);
        return res;
    }

    private void Helper(string digits, int curr, Dictionary<char, char[]> numCharMap, List<char> path,
        List<string> res) {
        if (path.Count == digits.Length) {
            res.Add(string.Join("", path));
            return;
        }

        foreach (var ch in numCharMap[digits[curr]]) {
            path.Add(ch);
            Helper(digits, curr + 1, numCharMap, path, res);
            path.RemoveAt(path.Count - 1);
        }
    }
}