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
        TreeNode ans = null;

        bool Helper(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null) return false;
            var l = Helper(root.left, p, q);
            var r = Helper(root.right, p, q);
            if (l && r || (root.val == p.val || root.val == q.val) && (l || r)) ans = root;
            return l || r || (root.val == p.val || root.val == q.val);
        }

        Helper(root, p, q);
        return ans;
    }
}