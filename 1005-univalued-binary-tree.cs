/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public bool IsUnivalTree(TreeNode root) {
                int val = root.val;
                bool Helper(TreeNode root) {
                    if (root == null) return true;
                    var left = Helper(root.left);
                    var right = Helper(root.right);
                    return left && right && root.val == val;
                }
                return Helper(root);
    }
}