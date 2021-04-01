/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<int> LargestValues(TreeNode root) {
        var res = new List<int>();
        if (root == null) return res;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0) {
            var count = queue.Count;
            var tmp = new List<int>();
            for (var i = 0; i < count; i++) {
                var node = queue.Dequeue();
                tmp.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            res.Add(tmp.Max());
        }

        return res;
    }
}