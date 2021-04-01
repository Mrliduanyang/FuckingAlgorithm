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
    public IList<int> BoundaryOfBinaryTree(TreeNode root) {
        var res = new List<int>();

        bool IsLeaf(TreeNode node) {
            return node.left == null && node.right == null;
        }

        void AddLeaves(TreeNode node) {
            if (IsLeaf(node)) {
                res.Add(node.val);
            }
            else {
                if (node.left != null) AddLeaves(node.left);
                if (node.right != null) AddLeaves(node.right);
            }
        }

        if (root == null) return res;
        if (!IsLeaf(root)) res.Add(root.val);
        var node = root.left;
        // 添加左边界
        while (node != null) {
            if (!IsLeaf(node)) res.Add(node.val);
            if (node.left != null)
                node = node.left;
            else
                node = node.right;
        }

        AddLeaves(root);
        var stack = new Stack<int>();
        node = root.right;
        while (node != null) {
            if (!IsLeaf(node)) stack.Push(node.val);
            if (node.right != null)
                node = node.right;
            else
                node = node.left;
        }

        res.AddRange(stack);
        return res;
    }
}