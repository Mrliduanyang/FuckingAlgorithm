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
    public int MaxPathSum(TreeNode root) {
                int res = int.MinValue;
                int Helper(TreeNode node) {
                    if (node == null) return 0;
                    int left = Math.Max(Helper(node.left), 0);
                    int right = Math.Max(Helper(node.right), 0);
                    int cur = node.val + left + right;
                    res = Math.Max(res, cur);
                    return node.val + Math.Max(left, right);
                }
                Helper(root);
                return res;
    }
}