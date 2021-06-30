using System.Collections.Generic;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) return "";

        var res = new List<string>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0) {
            var cur = queue.Dequeue();
            if (cur == null) {
                res.Add("null");
                continue;
            }
            res.Add(cur.val.ToString());
            queue.Enqueue(cur.left);
            queue.Enqueue(cur.right);
        }

        return string.Join(",", res);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == "") return null;
        var nodes = new Queue<string>(data.Split(","));

        var queue = new Queue<TreeNode>();
        var root = new TreeNode(int.Parse(nodes.Dequeue()));
        queue.Enqueue(root);
        while (queue.Count != 0) {
            var cur = queue.Dequeue();
            var left = nodes.Dequeue();
            cur.left = left == "null" ? null : new TreeNode(int.Parse(left));
            if (cur.left != null) queue.Enqueue(cur.left);
            var right = nodes.Dequeue();
            cur.right = right == "null" ? null : new TreeNode(int.Parse(right));
            if (cur.right != null) queue.Enqueue(cur.right);
        }

        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));