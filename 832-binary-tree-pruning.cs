/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode PruneTree(TreeNode root) {
        return ContainsOne(root) ? root : null;
    }

    public bool ContainsOne(TreeNode node) {
        if (node == null) return false;
        bool left = ContainsOne(node.left);
        bool right = ContainsOne(node.right);
        if (!left) node.left = null;
        if (!right) node.right = null;
        return node.val == 1 || left || right;
    }
}