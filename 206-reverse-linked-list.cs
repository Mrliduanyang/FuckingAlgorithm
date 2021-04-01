/**
 * Definition for singly-linked list.
 * public class ListNode {
 * public int val;
 * public ListNode next;
 * public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        ListNode helper(ListNode node) {
            if (node.next == null) return node;
            var last = helper(node.next);
            node.next.next = node;
            node.next = null;
            return last;
        }

        return head == null ? head : helper(head);
    }
}