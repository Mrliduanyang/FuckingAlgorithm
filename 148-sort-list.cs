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
public ListNode SortList(ListNode head) {
                if (head == null || head.next == null) {
                    return head;
                }

                ListNode Cut(ListNode head, int n) {
                    while (head != null && n > 1) {
                        head = head.next;
                        n--;
                    }
                    if (head == null) { return null; }
                    var res = head.next;
                    head.next = null;
                    return res;

                }
                ListNode Merge(ListNode left, ListNode right) {
                    var dummy = new ListNode();
                    var p = dummy;
                    while (left != null && right != null) {
                        if (left.val < right.val) {
                            p.next = left;
                            left = left.next;
                        } else {
                            p.next = right;
                            right = right.next;
                        }
                        p = p.next;
                    }
                    p.next = left != null ? left : right;
                    return dummy.next;
                }
                // 链表长度
                int len = 0;
                var p = head;
                while (p != null) {
                    len++;
                    p = p.next;
                }

                var dummy = new ListNode();
                dummy.next = head;
                for (int i = 1; i < len; i *= 2) {
                    // cur是新一组的头
                    var cur = dummy.next;
                    // tail是上一组的尾巴
                    var tail = dummy;
                    while (cur != null) {
                        var left = cur;
                        var right = Cut(left, i);
                        cur = Cut(right, i);
                        tail.next = Merge(left, right);
                        while (tail.next != null) tail = tail.next;
                    }
                }
                return dummy.next;
            }
}