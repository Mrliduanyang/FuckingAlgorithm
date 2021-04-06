public class MyCircularQueue {
    private int[] queue;
    private int headIdx;
    private int count;
    private int cap;

    public MyCircularQueue(int k) {
        cap = k;
        queue = new int[k];
        headIdx = 0;
        count = 0;
    }

    public bool EnQueue(int value) {
        if (count == cap) return false;
        queue[(headIdx + count) % cap] = value;
        count += 1;
        return true;
    }

    public bool DeQueue() {
        if (count == 0) return false;
        headIdx = (headIdx + 1) % cap;
        count -= 1;
        return true;
    }

    public int Front() {
        if (count == 0) return -1;
        return queue[headIdx];
    }

    public int Rear() {
        if (count == 0) return -1;
        var tailIdx = (headIdx + count - 1) % cap;
        return queue[tailIdx];
    }

    public bool IsEmpty() {
        return count == 0;
    }

    public bool IsFull() {
        return count == cap;
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */