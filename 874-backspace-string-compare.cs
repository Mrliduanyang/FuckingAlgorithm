public class Solution {
    public bool BackspaceCompare(string S, string T) {
        var stack1 = new Stack<char>();
        var stack2 = new Stack<char>();
        foreach (var ch in S) {
            if (ch != '#') stack1.Push(ch);
            if (ch == '#' && stack1.Count != 0) stack1.Pop();
        }

        foreach (var ch in T) {
            if (ch != '#') stack2.Push(ch);
            if (ch == '#' && stack2.Count != 0) stack2.Pop();
        }

        return String.Join("", stack1.ToArray()) == String.Join("", stack2.ToArray());
    }
}