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
    public IList<int> InorderTraversal (TreeNode root) {
var res = new List<int>();
                var stack = new Stack<TreeNode>();
                // root为null并且栈空，结束
                while (root != null || stack.Count != 0) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                    root = stack.Pop();
                    res.Add(root.val);
                    root = root.right;
                } 
                return res;
     }
}