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
    public bool CheckSubTree(TreeNode t1, TreeNode t2) {
        bool Check(TreeNode t1, TreeNode t2) {
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null || t1.val != t2.val) return false;
            return Check(t1.left, t2.left) && Check(t1.right, t2.right);
        }

        bool Helper(TreeNode t1, TreeNode t2) {
            if (t1 == null) return false;
            return Check(t1, t2) || Helper(t1.left, t2) || Helper(t1.right, t2);
        }

        return Helper(t1, t2);
    }
}