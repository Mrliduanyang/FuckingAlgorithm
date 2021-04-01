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
            public bool IsBalanced(TreeNode root) {
                (int, bool) Helper(TreeNode root) {
                    if (root == null) {
                        return (0, true);
                    } else {
                        var(lHeight, lBalanceed) = Helper(root.left);
                        var(rHeight, rBalanceed) = Helper(root.right);
                        return (Math.Max(lHeight, rHeight) + 1, Math.Abs(lHeight - rHeight) <= 1 && lBalanceed && rBalanceed);
                    }
                }
                var(_, res) = Helper(root);
                return res;
            }
}