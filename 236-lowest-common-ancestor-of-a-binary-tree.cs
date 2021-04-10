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
        TreeNode Helper(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null || root == p || root == q) return root;
            var l = Helper(root.left, p, q);
            var r = Helper(root.right, p, q);
            if (l != null && r != null) return root;
            return l == null ? r : l;
        }

        return Helper(root, p, q);
    }
}