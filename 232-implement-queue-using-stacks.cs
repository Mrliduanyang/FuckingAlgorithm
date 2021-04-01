public class MyQueue {
    private Stack<int> popStack;

    private Stack<int> pushStack;

    public MyQueue() {
        pushStack = new Stack<int>();
        popStack = new Stack<int>();
    }

    public void Push(int x) {
        pushStack.Push(x);
    }

    public int Pop() {
        if (popStack.Count == 0)
            while (pushStack.Count != 0)
                popStack.Push(pushStack.Pop());
        return popStack.Pop();
    }

    public int Peek() {
        if (popStack.Count == 0)
            while (pushStack.Count != 0)
                popStack.Push(pushStack.Pop());
        return popStack.Peek();
    }

    public bool Empty() {
        return pushStack.Count == 0 && popStack.Count == 0;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */