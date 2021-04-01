using System;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode AddOneRow(TreeNode root, int v, int d) {
        if (d == 1) {
            var tmp = new TreeNode(v);
            tmp.left = root;
            return tmp;
        }

        var queue = new Queue<TreeNode>();
        var prevRow = new List<TreeNode>();
        var height = 1;
        queue.Enqueue(root);
        while (queue.Count != 0) {
            var count = queue.Count;
            for (var i = 0; i < count; i++) {
                var node = queue.Dequeue();
                if (height == d - 1) prevRow.Add(node);
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }

            if (++height == d) break;
        }

        foreach (var node in prevRow) {
            Console.WriteLine(node.val);
            var tmp = new TreeNode(v);
            tmp.left = node.left;
            node.left = tmp;
            tmp = new TreeNode(v);
            tmp.right = node.right;
            node.right = tmp;
        }

        return root;
    }
}