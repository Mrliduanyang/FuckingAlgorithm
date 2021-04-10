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
            var l = Helper(node.left, p, q);
            var r = Helper(node.right, p, q);
            if (l != null && r != null) return node;
            return l == null ? r : l;
        }

        return Helper(root, p, q);
    }
}