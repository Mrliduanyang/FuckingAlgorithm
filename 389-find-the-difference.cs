public class Solution {
    public char FindTheDifference(string s, string t) {
        var res = 0;
        var lens = s.Length;
        for (var i = 0; i < lens; i++) res ^= s[i] ^ t[i];
        res ^= t[lens];
        return (char) res;
    }
}