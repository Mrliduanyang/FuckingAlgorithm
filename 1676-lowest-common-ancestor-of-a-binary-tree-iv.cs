using System.Linq;

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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode[] nodes) {
        TreeNode Helper(TreeNode node) {
            if (node == null || nodes.Contains(node)) return node;
            var l = Helper(node.left);
            var r = Helper(node.right);
            if (l != null && r != null) return node;
            return l == null ? r : l;
        }

        return Helper(root);
    }
}