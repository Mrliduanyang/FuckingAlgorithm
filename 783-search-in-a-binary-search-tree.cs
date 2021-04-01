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
    public TreeNode SearchBST(TreeNode root, int val) {
                TreeNode Helper(TreeNode node) {
                    if (node == null || node.val == val) return node;
                    return val < node.val ? Helper(node.left) : Helper(node.right);

                }
                return Helper(root);
    }
}