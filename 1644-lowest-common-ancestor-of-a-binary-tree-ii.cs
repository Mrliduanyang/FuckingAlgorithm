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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        TreeNode ans = null;

        bool Helper(TreeNode node) {
            if (node == null) return false;
            var left = Helper(node.left);
            var right = Helper(node.right);
            if ((left && right) || ((node.val == p.val || node.val == q.val) && (left || right))) {
                ans = node;
            }

            return left || right || (node.val == p.val || node.val == q.val);
        }

        Helper(root);
        return ans;
    }
}