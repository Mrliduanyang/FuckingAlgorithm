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
    public int SumOfLeftLeaves(TreeNode root) {
        if (root == null) return 0;
        var queue = new Queue<TreeNode>();
        var res = new List<int>();
        queue.Enqueue(root);
        while (queue.Count != 0) {
            var node = queue.Dequeue();
            if (node.left != null) {
                queue.Enqueue(node.left);
                var leftChild = node.left;
                if (leftChild.left == null && leftChild.right == null) res.Add(node.left.val);
            }

            if (node.right != null) queue.Enqueue(node.right);
        }

        var sum = 0;
        foreach (var item in res) sum += item;
        return sum;
    }
}