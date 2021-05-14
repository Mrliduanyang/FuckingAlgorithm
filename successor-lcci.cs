using System.Collections.Generic;

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
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        if (p.right != null) {
            p = p.right;
            while (p.left != null) p = p.left;
            return p;
        }

        var stack = new Stack<TreeNode>();
        var inorder = int.MinValue;
        while (true) {
            while (root != null) {
                stack.Push(root);
                root = root.left;
            }

            if (stack.Count == 0) break;
            root = stack.Pop();
            if (inorder == p.val) return root;
            inorder = root.val;
            root = root.right;
        }

        return null;
    }
}