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
    public TreeNode ConvertBST(TreeNode root) {
        int sum = 0;

        void Helper(TreeNode node) {
            if (node != null) {
                Helper(node.right);
                sum += node.val;
                node.val = sum;
                Helper(node.left);
            }
        }

        Helper(root);
        return root;
    }
}