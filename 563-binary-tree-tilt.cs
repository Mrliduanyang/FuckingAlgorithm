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
using System.Collections;
public class Solution {
    int tilt = 0;

    public int FindTilt(TreeNode root) {
        Helper(root);
        return tilt;
    }
    public int Helper(TreeNode root) {
        if (root == null)
            return 0;
        int left = Helper(root.left);
        int right = Helper(root.right);
        tilt += Math.Abs(left - right);
        return left + right + root.val;
    }
}