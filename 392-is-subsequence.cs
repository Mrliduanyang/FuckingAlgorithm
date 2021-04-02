public class Solution {
    public bool IsSubsequence(string s, string t) {
        int n = s.Length, m = t.Length;
        int i = 0, j = 0;
        while (i < n && j < m) {
            if (s[i] == t[j]) {
                i++;
            }

            j++;
        }

        return i == n;
    }
}