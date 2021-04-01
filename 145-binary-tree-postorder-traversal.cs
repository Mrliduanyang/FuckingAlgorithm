/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
public class Solution {
    public IList<int> PostorderTraversal(TreeNode root) {
        var stack = new Stack<TreeNode>();
        var res = new List<int>();
        while (true) {
            while (root != null) {
                res.Add(root.val);
                stack.Push(root.left);
                root = root.right;
            }

            if (stack.Count == 0) break;
            root = stack.Pop();
        }

        res.Reverse();
        return res;
    }
}