using System.Collections.Generic;

public class Solution {
    public bool CanPermutePalindrome(string s) {
        var dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; ++i) {
            dict[s[i]] = dict.GetValueOrDefault(s[i], 0) + 1;
        }

        int count = 0;
        foreach (var (key, val) in dict) {
            count += (val % 2);
        }

        return count <= 1;
    }
}