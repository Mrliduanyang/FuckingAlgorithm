/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var res = new List<IList<int>>();
        if (root == null) return res;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        var depth = 1;

        while (queue.Count != 0) {
            int count = queue.Count;
            var tmp = new List<int>();
            for (var i = 0; i < count; i++) {
                var node = queue.Dequeue();
                if (depth % 2 == 0)
                    tmp.Insert(0, node.val);
                else
                    tmp.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            depth++;
            res.Add(tmp);
        }

        return res;
    }
}