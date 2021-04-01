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
    public int GoodNodes(TreeNode root) {
                        var res = 0;
                void Helper(TreeNode node, int max) {
                    if (node == null) return;
                    if (node.val >= max) {
                        ++res;
                        max = node.val;
                    }
                    Helper(node.left, max);
                    Helper(node.right, max);
                }
                Helper(root, root.val);
                return res;
    }
}