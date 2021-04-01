public class Solution {
    public bool IsIsomorphic(string s, string t) {
        var dict1 = new Dictionary<char, int>();
        var res1 = new StringBuilder();
        var count1 = 0;
        foreach (var ch in s) {
            if (!dict1.ContainsKey(ch)) {
                dict1[ch] = count1;
                count1++;
            }

            res1.Append(dict1[ch]);
        }

        var dict2 = new Dictionary<char, int>();
        var res2 = new StringBuilder();
        var count2 = 0;
        foreach (var ch in t) {
            if (!dict2.ContainsKey(ch)) {
                dict2[ch] = count2;
                count2++;
            }

            res2.Append(dict2[ch]);
        }

        return res1.ToString() == res2.ToString();
    }
}