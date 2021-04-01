public class Solution {
    public bool IsAnagram(string s, string t) {
        var dict = new Dictionary<char, int>();

        foreach (var ch in s) dict[ch] = dict.GetValueOrDefault(ch, 0) + 1;
        foreach (var ch in t)
            if (dict.ContainsKey(ch))
                dict[ch]--;
            else
                return false;
        return dict.Values.All(item => { return item == 0; });
    }
}