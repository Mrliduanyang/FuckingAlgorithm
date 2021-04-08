using System.Collections.Generic;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int x) { val = x; }
 * }
 */

// using System.Collections.Generic;
public class Solution {
    public IList<int> PreorderTraversal(TreeNode root) {
        if (root == null) return new List<int>();
        var stack = new Stack<TreeNode>();
        var res = new List<int>();
        while (true) {
            while (root != null) {
                res.Add(root.val);
                stack.Push(root.right);
                root = root.left;
            }

            if (stack.Count == 0) break;
            root = stack.Pop();
        }

        return res;
    }
}