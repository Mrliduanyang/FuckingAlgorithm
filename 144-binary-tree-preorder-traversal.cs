/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

// using System.Collections.Generic;
public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) {
        if (root == null) return new List<int> { };
        var stack = new Stack<TreeNode>();
        var res = new List<int>();
        stack.Push(root);
        while (stack.Count != 0) {
            var node = stack.Pop();
            res.Add(node.val);
            if (node.right != null) {
                stack.Push(node.right);
            }
            if (node.left != null) {
                stack.Push(node.left);
            }
        }
        return res;
    }
}