/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head)
        {
                if (head == null || head.next == null) return head;
                var slow = head;
                var fast = head.next;

                while (fast != null) {
                    if (slow.val == fast.val) {
                        // 如果fast 和 slow相等，fast前进
                        fast = fast.next;
                    } else {
                        // 如果fast 和 slow 不等，都要前进
                        slow.next = fast;
                        slow = slow.next;
                        fast = fast.next;
                    }
                }
                slow.next = null;
                return head;
        }

}