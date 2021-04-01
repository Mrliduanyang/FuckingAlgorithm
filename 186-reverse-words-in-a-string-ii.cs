public class Solution {
    public void ReverseWords(char[] s) {
        void Reverse(int left, int right) {
            while (left < right) {
                var temp = s[left];
                s[left++] = s[right];
                s[right--] = temp;
            }
        }

        var i = 0;
        var j = 0;
        while (j < s.Length) {
            while (j < s.Length && s[j] != ' ') ++j;
            Reverse(i, j - 1);
            i = j + 1;
            ++j;
        }

        // Reverse(i, j - 1);
        Reverse(0, s.Length - 1);
    }
}