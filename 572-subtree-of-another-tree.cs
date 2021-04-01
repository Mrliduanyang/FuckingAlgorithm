/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsSubtree(TreeNode s, TreeNode t) {
                // 返回t是否是s的子树
                bool Check(TreeNode s, TreeNode t) {
                    if (s == null && t == null) {
                        return true;
                    }
                    if (s == null || t == null || s.val != t.val) {
                        return false;
                    }
                    return Check(s.left, t.left) && Check(s.right, t.right);
                }
                bool Helper(TreeNode s, TreeNode t) {
                    if (s == null) {
                        return false;
                    }
                    return Check(s, t) || Helper(s.left, t) || Helper(s.right, t);
                }

                return Helper(s, t);
    }
}