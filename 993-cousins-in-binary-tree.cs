using System;
using System.Collections.Generic;

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
    public bool IsCousins(TreeNode root, int x, int y) {
        int[] xRes = new[] {-1, -1}, yRes = new[] {-1, -1};

        var queue = new Queue<Tuple<TreeNode, TreeNode, int>>();
        queue.Enqueue(new Tuple<TreeNode, TreeNode, int>(root, null, 0));
        while (queue.Count != 0) {
            var count = queue.Count;
            for (var i = 0; i < count; ++i) {
                var (cur, curP, dep) = queue.Dequeue();
                if (cur.val == x) xRes = new[] {curP != null ? curP.val : 0, dep};
                if (cur.val == y) yRes = new[] {curP != null ? curP.val : 0, dep};
                if (cur.left != null) queue.Enqueue(new Tuple<TreeNode, TreeNode, int>(cur.left, cur, dep + 1));
                if (cur.right != null) queue.Enqueue(new Tuple<TreeNode, TreeNode, int>(cur.right, cur, dep + 1));
            }
        }

        // Console.WriteLine($"{xRes[0]},{xRes[1]}:{yRes[0]},{yRes[1]}");
        return xRes[1] == yRes[1] && xRes[0] != yRes[0];
    }
}