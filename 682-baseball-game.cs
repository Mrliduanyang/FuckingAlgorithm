public class Solution {
    public int CalPoints(string[] ops) {
        var stack = new Stack<int>();

        foreach(var op in ops) {
            if (op == "+") {
                int top = stack.Pop();
                int newtop = top + stack.Peek();
                stack.Push(top);
                stack.Push(newtop);
            } else if (op == "C") {
                stack.Pop();
            } else if (op == "D") {
                stack.Push(2 * stack.Peek());
            } else {
                stack.Push(int.Parse(op));
            }
        }
        return stack.Sum();
    }
    
}