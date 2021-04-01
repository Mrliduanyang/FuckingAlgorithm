/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    public string serialize(TreeNode root) {
        if (root == null) return string.Empty;

        var res = new List<string>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count != 0) {
            var node = queue.Dequeue();
            if (node == null) {
                res.Add("null");
                continue;
            }

            res.Add(node.val.ToString());
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        return string.Join(",", res);
    }

    public TreeNode deserialize(string data) {
        if (string.IsNullOrEmpty(data)) return null;

        var nodes = data.Split(',');
        var root = new TreeNode(int.Parse(nodes[0]));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var idx = 1;
        while (queue.Count != 0) {
            var node = queue.Dequeue();
            node.left = nodes[idx] == "null" ? null : new TreeNode(int.Parse(nodes[idx]));
            if (node.left != null) queue.Enqueue(node.left);
            idx++;

            node.right = nodes[idx] == "null" ? null : new TreeNode(int.Parse(nodes[idx]));
            if (node.right != null) queue.Enqueue(node.right);
            idx++;
        }

        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// String tree = ser.serialize(root);
// TreeNode ans = deser.deserialize(tree);
// return ans;