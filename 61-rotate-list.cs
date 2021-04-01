/**
 * Definition for singly-linked list.
 * public class ListNode {
 * public int val;
 * public ListNode next;
 * public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RotateRight(ListNode head, int k) {
        if (head == null) return null;
        if (head.next == null) return head;

        ListNode oldTail = head;
        var n = 1;
        while (oldTail.next != null) {
            oldTail = oldTail.next;
            ++n;
        }

        oldTail.next = head;

        ListNode newTail = head;
        for (var i = 0; i < n - k % n - 1; i++)
            newTail = newTail.next;
        ListNode new_head = newTail.next;
        newTail.next = null;
        return new_head;
    }
}