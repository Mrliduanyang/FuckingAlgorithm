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
        // 将相邻的两个节点连接起来。

        if (root == null) return null;
        Helper(root.left, root.right);
        return root;
    }

    private void Helper(Node node1, Node node2) {
        if (node1 == null || node2 == null) return;
        node1.next = node2;
        // 连接相同父节点的两个子节点。
        Helper(node1.left, node1.right);
        Helper(node2.left, node2.right);
        // 连接跨父节点的两个子节点。
        Helper(node1.right, node2.left);
    }
}