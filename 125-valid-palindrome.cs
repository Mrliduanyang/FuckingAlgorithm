public class Solution {
    public bool IsPalindrome(string s) {
                var sgood = new StringBuilder();
                foreach (var ch in s) {
                    if (char.IsLetterOrDigit(ch)) {
                        sgood.Append(ch);
                    }
                }
                int left = 0, right = sgood.Length - 1;
                while (left < right) {
                    if (char.ToLower(sgood[left]) != char.ToLower(sgood[right])) {
                        return false;
                    }
                    ++left;
                    --right;
                }
                return true;
    }
}