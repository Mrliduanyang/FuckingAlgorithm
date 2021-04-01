/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public int MaxDepth(Node root) {
        if (root == null) return 0;
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        var height = 0;
        while (queue.Count != 0) {
            var count = queue.Count;
            height++;
            for (var i = 0; i < count; i++) {
                var tmp = queue.Dequeue();
                foreach (var child in tmp.children) queue.Enqueue(child);
            }
        }

        return height;
    }
}