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

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public List<List<int>> VerticalOrder(TreeNode root) {
        if (root == null) return new List<List<int>>();
        var nodeIdxMap = new Dictionary<TreeNode, int>();
        var res = new SortedDictionary<int, List<int>>();
        var queue = new Queue<TreeNode>();
        nodeIdxMap[root] = 0;
        queue.Enqueue(root);
        while (queue.Count != 0) {
            var node = queue.Dequeue();
            var idx = nodeIdxMap[node];
            if (!res.ContainsKey(idx)) {
                res[idx] = new List<int>();
            }

            res[idx].Add(node.val);

            if (node.left != null) {
                queue.Enqueue(node.left);
                nodeIdxMap[node.left] = idx - 1;
            }

            if (node.right != null) {
                queue.Enqueue(node.right);
                nodeIdxMap[node.right] = idx + 1;
            }
        }

        return res.Values.ToList();
    }
}