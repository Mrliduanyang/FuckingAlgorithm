using System.Collections.Generic;

public class SortedStack {
    private Stack<int> stack;
    private Stack<int> tmp;

    public SortedStack() {
        stack = new Stack<int>();
        tmp = new Stack<int>();
    }

    public void Push(int val) {
        while (stack.Count != 0 && stack.Peek() < val) {
            tmp.Push(stack.Pop());
        }

        stack.Push(val);
        while (tmp.Count != 0) {
            stack.Push(tmp.Pop());
        }
    }

    public void Pop() {
        if (stack.Count != 0) {
            stack.Pop();
        }
    }

    public int Peek() {
        if (stack.Count != 0) {
            return stack.Peek();
        }

        return -1;
    }

    public bool IsEmpty() {
        return stack.Count == 0;
    }
}

/**
 * Your SortedStack object will be instantiated and called as such:
 * SortedStack obj = new SortedStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.IsEmpty();
 */