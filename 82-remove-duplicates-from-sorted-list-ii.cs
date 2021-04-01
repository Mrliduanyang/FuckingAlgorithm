/**
 * Definition for singly-linked list.
 * public class ListNode {
 * public int val;
 * public ListNode next;
 * public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        var dummy = new ListNode(0);
        dummy.next = head;
        // if(head == null) return head;
        var slow = dummy;
        var fast = head;
        while (fast != null && fast.next != null)
            if (slow.next.val != fast.next.val) {
                slow = slow.next;
                fast = fast.next;
            }
            else {
                while (fast.next != null && fast.val == fast.next.val) fast = fast.next;
                fast = fast.next;
                slow.next = fast;
            }

        return dummy.next;
    }
}