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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        TreeNode Helper(TreeNode node, TreeNode p, TreeNode q) {
            if (node == null || node == p || node == q) return node;
            var left = Helper(node.left, p, q);
            var right = Helper(node.right, p, q);
            if (left != null && right != null) return node;
            return left == null ? right : left;
        }

        return Helper(root, p, q);
    }
}