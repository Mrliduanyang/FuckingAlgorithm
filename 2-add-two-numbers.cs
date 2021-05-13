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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode head = null, tail = null;
        var carry = 0;
        while (l1 != null || l2 != null) {
            var n1 = l1 != null ? l1.val : 0;
            var n2 = l2 != null ? l2.val : 0;
            var sum = n1 + n2 + carry;
            if (head == null) {
                head = tail = new ListNode(sum % 10);
            }
            else {
                tail.next = new ListNode(sum % 10);
                tail = tail.next;
            }

            carry = sum / 10;
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
        }

        if (carry > 0) {
            tail.next = new ListNode(carry);
        }

        return head;
    }
}