using System.Collections;

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
public class Solution {
    public TreeNode FindNearestRightNode(TreeNode root, TreeNode u) {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count != 0) {
            var count = queue.Count;
            for (int i = 0; i < count; i++) {
                var node = queue.Dequeue();
                if (node == u) return i == count - 1 ? null : queue.Dequeue();
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }

        return null;
    }
}