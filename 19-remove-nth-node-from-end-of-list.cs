/**
 * Definition for singly-linked list.
 * public class ListNode {
 * public int val;
 * public ListNode next;
 * public ListNode(int val=0, ListNode next=null) {
 * this.val = val;
 * this.next = next;
 * }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        var dummy = new ListNode();
        dummy.next = head;

        var slow = dummy;
        var fast = dummy;
        var i = 0;
        // 快指针走n+1步
        while (i <= n) {
            fast = fast.next;
            i++;
        }

        while (fast != null) {
            slow = slow.next;
            fast = fast.next;
        }

        var tmp = slow.next;
        slow.next = tmp.next;
        return dummy.next;
    }
}