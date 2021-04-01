/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseBetween(ListNode head, int left, int right) {
                var dummy = new ListNode(-1);
                dummy.next = head;
                var pre = dummy;
                for (int i = 0; i < left - 1; ++i) {
                    pre = pre.next;
                }
                var cur = pre.next;
                ListNode next;
                for (int i = 0; i < right - left; ++i) {
                    next = cur.next;
                    cur.next = next.next;
                    next.next = pre.next;
                    pre.next = next;
                }
                return dummy.next;
    }
}