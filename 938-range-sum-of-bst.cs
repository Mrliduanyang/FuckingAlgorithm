using System.Security.Cryptography;

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
    public int RangeSumBST(TreeNode root, int low, int high) {
        int Helper(TreeNode node) {
            if (node == null) return 0;
            if (node.val > high) {
                return Helper(node.left);
            }

            if (node.val < low) {
                return Helper(node.right);
            }

            return node.val + Helper(node.left) + Helper(node.right);
        }

        return Helper(root);
    }
}