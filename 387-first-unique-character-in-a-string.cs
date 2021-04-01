public class Solution {
    public int FirstUniqChar(string s) {
        var dict = new Dictionary<char, int>();
        foreach (var ch in s) dict[ch] = dict.GetValueOrDefault(ch, 0) + 1;
        for (var i = 0; i < s.Length; i++)
            if (dict[s[i]] == 1)
                return i;
        return -1;
    }
}