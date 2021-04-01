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
    public bool HasPathSum(TreeNode root, int sum) {
        // 递归实现，判断子问题有没有符合sum-root.val的
        return Helper(root, sum);
    }

    public bool Helper(TreeNode root, int sum) {
        if (root == null) return false;
        if (root.left == null && root.right == null) return sum == root.val;
        return Helper(root.left, sum - root.val) || Helper(root.right, sum - root.val);
    }
}