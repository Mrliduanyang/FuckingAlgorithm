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
        TreeNode Helper(TreeNode node) {
            if (p.val < node.val && q.val < node.val)
                return Helper(node.left);
            if (p.val > node.val && q.val > node.val)
                return Helper(node.right);
            return node;
        }

        return Helper(root);
    }
}