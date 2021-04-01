/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
public class Solution {
    public void Flatten(TreeNode root) {
        if (root == null) return;

        Flatten(root.left);
        Flatten(root.right);

        var left = root.left;
        var right = root.right;

        root.left = null;
        root.right = left;

        var p = root;
        while (p.right != null) p = p.right;
        p.right = right;
    }
}