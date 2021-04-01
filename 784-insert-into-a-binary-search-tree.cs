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
    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null) return new TreeNode(val);
        TreeNode pos = root;
        while (pos != null)
            if (val < pos.val) {
                if (pos.left == null) {
                    pos.left = new TreeNode(val);
                    break;
                }

                pos = pos.left;
            }
            else {
                if (pos.right == null) {
                    pos.right = new TreeNode(val);
                    break;
                }

                pos = pos.right;
            }

        return root;
    }
}