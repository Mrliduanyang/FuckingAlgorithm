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
    int pre;
    int ans;
                void DFS(TreeNode root) {
                    if (root == null) {
                        return;
                    }
                    DFS(root.left);
                    if (pre == -1) {
                        pre = root.val;
                    } else {
                        ans = Math.Min(ans, root.val - pre);
                        pre = root.val;
                    }
                    DFS(root.right);
                }


    public int GetMinimumDifference(TreeNode root) {
                ans = int.MaxValue;
                pre = -1;
                DFS(root);
                return ans;
    }
}