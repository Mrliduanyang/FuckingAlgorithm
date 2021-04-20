public class Solution {
    public int StrStr(string haystack, string needle) {
        int L = needle.Length, n = haystack.Length;
        for (var start = 0; start < n - L + 1; ++start)
            if (haystack.Substring(start, L) == needle)
                return start;
        return -1;
    }

    public int StrStr_KMP(string haystack, string needle) {
        int n = haystack.Length, m = needle.Length;
        if (m == 0) return 0;
        var next = new int[m];
        for (int i = 1, j = 0; i < m; ++i) {
            while (j > 0 && needle[i] != needle[j]) {
                j = next[j - 1];
            }

            if (needle[i] == needle[j]) {
                ++j;
            }

            next[i] = j;
        }

        for (int i = 0, j = 0; i < n; ++i) {
            while (j > 0 && haystack[i] != needle[j]) {
                j = next[j - 1];
            }

            if (haystack[i] == needle[j]) {
                ++j;
            }

            if (j == m) return i - m + 1;
        }

        return -1;
    }
}