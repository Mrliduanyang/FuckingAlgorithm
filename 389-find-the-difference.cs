public class Solution {
 public char FindTheDifference(string s, string t) {
        int res = 0;
        int lens = s.Length;
        for (int i = 0; i < lens; i ++) {
            res ^= s[i]^ t[i];
        }
        res ^= t[lens];
        return (char) res;

    }
}