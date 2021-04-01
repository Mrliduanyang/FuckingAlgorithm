public class Solution {
    public string RemoveDuplicates(string S) {
        var stack = new Stack<char>();
        foreach (var ch in S)
            if (stack.Count != 0 && ch == stack.Peek())
                stack.Pop();
            else
                stack.Push(ch);
        return new string(stack.Reverse().ToArray());
    }
}