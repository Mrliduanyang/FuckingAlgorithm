public class Solution {
    public int StrStr(string haystack, string needle) {
        int L = needle.Length, n = haystack.Length;
        for (var start = 0; start < n - L + 1; ++start)
            if (haystack.Substring(start, L) == needle)
                return start;
        return -1;
    }
}