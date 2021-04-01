/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;

    public Node() {}

    public Node(int _val) {
        val = _val;
        left = null;
        right = null;
    }

    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
    }
}
*/

public class Solution {
    public Node TreeToDoublyList(Node root) {
        Node first = null, last = null;

        void Helper(Node node) {
            if (node != null) {
                Helper(node.left);
                if (last != null) {
                    last.right = node;
                    node.left = last;
                }
                else {
                    first = node;
                }

                last = node;
                Helper(node.right);
            }
        }

        if (root == null) return null;
        Helper(root);
        last.right = first;
        first.left = last;
        return first;
    }
}