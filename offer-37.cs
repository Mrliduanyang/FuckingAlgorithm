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

        void Helper(TreeNode node) {
            if (node == null) {
                res.Add("null");
                return;
            }

            res.Add(node.val.ToString());
            Helper(node.left);
            Helper(node.right);
        }

        Helper(root);
        return string.Join(",", res);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if (data == "") return null;
        var nodes = new Queue<string>(data.Split(","));

        TreeNode Helper() {
            var node = nodes.Dequeue();
            if (node == "null") return null;
            var root = new TreeNode(int.Parse(node));
            root.left = Helper();
            root.right = Helper();
            return root;
        }

        return Helper();
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));