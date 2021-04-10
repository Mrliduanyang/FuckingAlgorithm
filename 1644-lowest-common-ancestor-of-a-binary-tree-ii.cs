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

        bool Helper(TreeNode node, TreeNode p, TreeNode q) {
            if (node == null) return false;
            var l = Helper(node.left, p, q);
            var r = Helper(node.right, p, q);
            if ((l && r) || ((node.val == p.val || node.val == q.val) && (l || r))) {
                ans = node;
            }

            return l || r || (node.val == p.val || node.val == q.val);
        }

        Helper(root, p, q);
        return ans;
    }
}