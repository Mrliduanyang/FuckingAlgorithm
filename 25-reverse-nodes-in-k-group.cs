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
    public ListNode ReverseKGroup(ListNode head, int k) {
        if (head == null) return null;

                ListNode a, b;
                a = b = head;
                for (int i = 0; i < k; i++) {
                    if (b == null) return head;
                    b = b.next;
                }
                var newHead = Reverse(a, b);
                a.next = ReverseKGroup(b, k);
                return newHead;
    }
    ListNode Reverse(ListNode a, ListNode b) {
                    ListNode pre, cur, nxt;
                    pre = null;
                    cur = a;
                    nxt = a;
                    // while 终止的条件改一下就行了
                    while (cur != b) {
                        nxt = cur.next;
                        cur.next = pre;
                        pre = cur;
                        cur = nxt;
                    }
                    // 返回反转后的头结点
                    return pre;
                }
}