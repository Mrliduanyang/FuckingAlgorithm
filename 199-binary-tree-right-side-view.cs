/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        // 层次遍历，获取每层的最后一个节点
        var res = new List<int>();
        if (root == null) return res;

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0) {
            var count = queue.Count;
            for (var i = 0; i < count; i++) {
                var node = queue.Dequeue();
                if (i == count - 1) res.Add(node.val);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }

        return res;
    }
}