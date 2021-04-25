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
    public TreeNode IncreasingBST(TreeNode root) {
        var dummy = new TreeNode(-1);
        var prev = dummy;

        void Helper(TreeNode node) {
            if (node == null) return;
            Helper(node.left);
            prev.right = node;
            node.left = null;
            prev = node;
            Helper(node.right);
        }

        Helper(root);
        return dummy.right;
    }
}