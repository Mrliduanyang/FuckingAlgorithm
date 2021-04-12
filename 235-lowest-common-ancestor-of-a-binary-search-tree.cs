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
            if (p.val < node.val && q.val < node.val)
                return Helper(node.left, p, q);
            if (p.val > node.val && q.val > node.val)
                return Helper(node.right, p, q);
            return node;
        }

        return Helper(root, p, q);
    }
}