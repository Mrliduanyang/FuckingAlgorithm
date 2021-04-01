public class Solution {
    public bool WordPattern(string pattern, string s) {
        var patterns = pattern.ToArray();
        var words = s.Split(" ");
        if (patterns.Length != words.Length) return false;
        var dict1 = new Dictionary<char, string>();
        var dict2 = new Dictionary<string, char>();
        for (var i = 0; i < patterns.Length; i++) {
            var ch = patterns[i];
            var word = words[i];
            if (dict1.ContainsKey(ch) && dict2.ContainsKey(word) && (dict1[ch] != word || dict2[word] != ch))
                return false;
            if (dict1.ContainsKey(ch) && !dict2.ContainsKey(word)) return false;
            if (!dict1.ContainsKey(ch) && dict2.ContainsKey(word)) return false;
            if (!dict1.ContainsKey(ch) && !dict2.ContainsKey(word)) {
                dict1[ch] = word;
                dict2[word] = ch;
            }
        }

        return true;
    }
}