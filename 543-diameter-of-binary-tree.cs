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
    public int DiameterOfBinaryTree(TreeNode root) {
        var ans = 1;

        int Helper(TreeNode root) {
            if (root == null) return 0;
            var l = Helper(root.left);
            var r = Helper(root.right);
            ans = Math.Max(ans, l + r + 1);
            return Math.Max(l, r) + 1;
        }

        Helper(root);
        return ans - 1;
    }
}