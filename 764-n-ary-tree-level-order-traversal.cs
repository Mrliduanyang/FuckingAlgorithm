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
using System.Collections;
public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        var res = new List<IList<int>>();
        if (root == null) {
            return res;
        }
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Count > 0) {
            var count = queue.Count;
            var tmp = new List<int>();
            for (int i = 0; i < count; i++) {
                var node = queue.Dequeue();
                tmp.Add(node.val);
                if (node.children != null && node.children.Any()) {
                    foreach (var child in node.children) {
                        queue.Enqueue(child);
                    }
                }
            }
            res.Add(tmp);
        }
        return res;
    }
}