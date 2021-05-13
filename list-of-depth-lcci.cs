using System.Collections;
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
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode[] ListOfDepth(TreeNode tree) {
        var res = new List<ListNode>();
        if (tree == null) return res.ToArray();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(tree);
        while (queue.Count != 0) {
            var count = queue.Count;
            var head = new ListNode(0);
            var dummyHead = head;
            for (var i = 0; i < count; ++i) {
                var node = queue.Dequeue();
                head.next = new ListNode(node.val);
                head = head.next;
                if (node.left != null) {
                    queue.Enqueue(node.left);
                }

                if (node.right != null) {
                    queue.Enqueue(node.right);
                }
            }

            res.Add(dummyHead.next);
        }

        return res.ToArray();
    }
}