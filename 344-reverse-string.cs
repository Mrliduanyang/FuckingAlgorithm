public class Solution {
    public void ReverseString(char[] s) {
        if (s.Length == 0) return;
        int start = 0, end = s.Length - 1;
        while (end > start) {
            var tmp = s[end];
            s[end] = s[start];
            s[start] = tmp;
            start++;
            end--;
        }
    }
}