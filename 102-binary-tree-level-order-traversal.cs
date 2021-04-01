/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

// using System.Collections.Generic;
public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var res = new List<IList<int>>();
        if (root == null) return res;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0) {
            int count = queue.Count;
            var tmp = new List<int>();
            for (int i = 0; i < count; i++) {
                var node = queue.Dequeue();
                tmp.Add(node.val);
                if (node.left != null) {
                    queue.Enqueue(node.left);
                }
                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }
            res.Add(tmp);
        }
        return res;
    }
}