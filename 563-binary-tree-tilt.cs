/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

using System;

public class Solution {
    private int tilt;

    public int FindTilt(TreeNode root) {
        Helper(root);
        return tilt;
    }

    public int Helper(TreeNode root) {
        if (root == null)
            return 0;
        var left = Helper(root.left);
        var right = Helper(root.right);
        tilt += Math.Abs(left - right);
        return left + right + root.val;
    }
}