public class MyStack {
    public Queue<int> queue;

    public MyStack() {
        queue = new Queue<int>();
    }

    public void Push(int x) {
        int n = queue.Count;
        queue.Enqueue(x);

        for (var i = 0; i < n; i++) queue.Enqueue(queue.Dequeue());
    }

    public int Pop() {
        return queue.Dequeue();
    }

    public int Top() {
        return queue.First();
    }

    public bool Empty() {
        return queue.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */