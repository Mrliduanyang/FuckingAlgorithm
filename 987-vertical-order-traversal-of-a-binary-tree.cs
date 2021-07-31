using System;
using System.Collections.Generic;
using System.Linq;

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
    public IList<IList<int>> VerticalTraversal(TreeNode root) {
        var queue = new Queue<Tuple<TreeNode, int, int>>();
        var dict = new Dictionary<int, List<Tuple<int, int>>>();
        queue.Enqueue(new Tuple<TreeNode, int, int>(root, 0, 0));
        while (queue.Count != 0) {
            var (cur, row, col) = queue.Dequeue();
            if (!dict.ContainsKey(col)) {
                dict[col] = new List<Tuple<int, int>>();
            }

            dict[col].Add(new Tuple<int, int>(cur.val, row));
            if (cur.left != null) {
                queue.Enqueue(new Tuple<TreeNode, int, int>(cur.left, row + 1, col - 1));
            }

            if (cur.right != null) {
                queue.Enqueue(new Tuple<TreeNode, int, int>(cur.right, row + 1, col + 1));
            }
        }

        var cols = dict.Keys.OrderBy(x => x);
        var res = new List<IList<int>>();
        foreach (var col in cols) {
            var data = dict[col];
            data.Sort((x, y) => {
                if (x.Item2 == y.Item2) {
                    return x.Item1 - y.Item1;
                }
                else {
                    return x.Item2 - y.Item2;
                }
            });
            res.Add(data.Select(x => x.Item1).ToList());
        }

        return res;
    }
}