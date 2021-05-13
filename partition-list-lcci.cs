/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode Partition(ListNode head, int x) {
        var small = new ListNode(0);
        var dummySmall = small;
        var large = new ListNode(0);
        var dummyLarge = large;
        while (head != null) {
            if (head.val < x) {
                small.next = head;
                small = small.next;
            }
            else {
                large.next = head;
                large = large.next;
            }

            head = head.next;
        }

        large.next = null;
        small.next = dummyLarge.next;
        return dummySmall.next;
    }
}