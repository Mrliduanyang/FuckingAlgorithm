using System;

public class Solution {
    public int MinDeletions(string s) {
        var freq = new int[26];
        foreach (var ch in s) {
            ++freq[ch - 'a'];
        }

        Array.Sort(freq, (x, y) => y - x);
        var res = 0;
        for (var i = 1; i < 26; ++i) {
            while (freq[i] > 0 && freq[i - 1] <= freq[i]) {
                --freq[i];
                ++res;
            }
        }

        return res;
    }
}