/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}
*/

public class Solution {
    public Node Flatten(Node head) {
        if (head == null) return head;

        var dummy = new Node(0, null, head, null);
        Node curr, prev = dummy;

        var stack = new Stack<Node>();
        stack.Push(head);

        while (stack.Count != 0) {
            curr = stack.Pop();
            prev.next = curr;
            curr.prev = prev;

            if (curr.next != null) stack.Push(curr.next);
            if (curr.child != null) {
                stack.Push(curr.child);
                curr.child = null;
            }

            prev = curr;
        }

        dummy.next.prev = null;
        return dummy.next;
    }
}