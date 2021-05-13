using System;
using System.Collections.Generic;
using System.Linq;

public class StackOfPlates {
    private List<Stack<int>> stackSet;
    private int cap;

    public StackOfPlates(int cap) {
        stackSet = new List<Stack<int>>();
        this.cap = cap;
    }

    public void Push(int val) {
        if (cap == 0) return;
        if (stackSet.Count == 0 || stackSet.Last().Count >= cap) {
            stackSet.Add(new Stack<int>());
        }

        stackSet.Last().Push(val);
    }

    public int Pop() {
        return PopAt(stackSet.Count - 1);
    }

    public int PopAt(int index) {
        if (stackSet.Count == 0 || stackSet.Count <= index) return -1;
        var val = stackSet[index].Pop();
        if (stackSet[index].Count == 0) {
            stackSet.RemoveAt(index);
        }

        return val;
    }
}

/**
 * Your StackOfPlates object will be instantiated and called as such:
 * StackOfPlates obj = new StackOfPlates(cap);
 * obj.Push(val);
 * int param_2 = obj.Pop();
 * int param_3 = obj.PopAt(index);
 */