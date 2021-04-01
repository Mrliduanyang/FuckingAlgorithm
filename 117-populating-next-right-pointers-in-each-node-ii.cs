/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        if (root == null) return null;
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count != 0) {
            int n = queue.Count;
            Node dummy = null;
            for (var i = 0; i < n; i++) {
                var node = queue.Dequeue();
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
                if (i != 0) dummy.next = node;
                dummy = node;
            }
        }

        return root;
    }
}