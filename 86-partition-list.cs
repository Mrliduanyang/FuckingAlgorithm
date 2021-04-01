/**
 * Definition for singly-linked list.
 * public class ListNode {
 * public int val;
 * public ListNode next;
 * public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        if (head == null || head.next == null) return head;
        var beforeHead = new ListNode();
        var afterHead = new ListNode();
        var before = beforeHead;
        var after = afterHead;
        while (head != null) {
            if (head.val < x) {
                before.next = head;
                before = before.next;
            }
            else {
                after.next = head;
                after = after.next;
            }

            head = head.next;
        }

        after.next = null;
        before.next = afterHead.next;
        return beforeHead.next;
    }
}