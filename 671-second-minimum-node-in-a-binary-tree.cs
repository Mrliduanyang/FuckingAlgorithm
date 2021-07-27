using System;

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
    public int FindSecondMinimumValue(TreeNode root) {
        if (root == null) return -1;
        int min = root.val;

        int Helper(TreeNode root) {
            if (root == null) return -1;
            if (root.val > min) return root.val;
            var left = Helper(root.left);
            var right = Helper(root.right);
            if (left == -1) return right;
            if (right == -1) return left;
            return Math.Min(left, right);
        }

        return Helper(root);
    }
}