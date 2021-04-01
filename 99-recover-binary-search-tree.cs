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
    public void RecoverTree(TreeNode root) {
                var stack = new Stack<TreeNode>();
                TreeNode x = null, y = null, pred = null;
                void Swap(TreeNode x, TreeNode y) {
                    int tmp = x.val;
                    x.val = y.val;
                    y.val = tmp;
                }
                while (true) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                    if (stack.Count == 0) break;
                    root = stack.Pop();
                    if (pred != null && root.val < pred.val) {
                        y = root;
                        if (x == null) {
                            x = pred;
                        } else {
                            break;
                        }
                    }
                    pred = root;
                    root = root.right;
                }

                Swap(x, y);
    }
}