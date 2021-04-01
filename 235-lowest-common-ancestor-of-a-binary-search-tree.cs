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
            if (p.val < root.val && q.val < root.val)
                return Helper(root.left, p, q);
            if (p.val > root.val && q.val > root.val)
                return Helper(root.right, p, q);
            return root;
        }

        return Helper(root, p, q);
    }
}