public class Solution {
    public string ReverseWords(string s) {
        int slow = 0, fast = 0;
        var stack = new Stack<string>();
        var n = s.Length;
        while (slow <= fast && fast < n) {
            while (slow < n && s[slow] == ' ') slow++;
            if (slow == n) break;
            fast = slow + 1;
            while (fast < s.Length && s[fast] != ' ') fast++;
            stack.Push(s.Substring(slow, fast - slow));
            slow = fast;
        }

        return string.Join(" ", stack.ToList());
    }
}