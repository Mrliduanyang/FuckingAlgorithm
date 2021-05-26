using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public string ReverseParentheses(string s) {
        var stack = new Stack<string>();
        var sb = new StringBuilder();
        foreach (var ch in s) {
            if (ch == '(') {
                stack.Push(sb.ToString());
                sb.Clear();
            } else if (ch == ')') {
                var tmp = sb.ToString().Reverse();
                sb.Clear();
                sb.Append(string.Join("", tmp));
                sb.Insert(0, stack.Pop());
            } else {
                sb.Append(ch);
            }
        }
        return sb.ToString();
    }
}
