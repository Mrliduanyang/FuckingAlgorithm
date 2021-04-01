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
    public TreeNode MergeTrees(TreeNode t1, TreeNode t2) {
        return Helper(t1, t2);
    }
    public TreeNode Helper(TreeNode t1, TreeNode t2){
        if(t1 == null && t2 == null){
            return null;
        }
        if(t1 == null) return t2;
        if(t2 == null) return t1;

        TreeNode merged = new TreeNode(t1.val + t2.val);
        merged.left = Helper(t1.left, t2.left);
        merged.right = Helper(t1.right, t2.right);
        return merged;
    }
}