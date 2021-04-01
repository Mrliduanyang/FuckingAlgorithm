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
    public int SumNumbers(TreeNode root) {
        return Helper(root, 0);
    }

    public int Helper(TreeNode root, int curr) {
        if (root == null) return 0;

        curr = curr * 10 + root.val;

        if (root.left == null && root.right == null) return curr;
        return Helper(root.left, curr) + Helper(root.right, curr);
    }
}