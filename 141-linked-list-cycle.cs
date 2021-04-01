/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public bool HasCycle(ListNode head) {
        // 如果链表以null结尾，肯定不存在环
        if(head == null || head.next == null) return false;

        var slow = head;
        var fast = head.next;

        while(slow != fast){
            // fast探测到null，存在环，同时保证下面fast赋值的合法性
            if(fast == null || fast.next == null) return false;
            slow = slow.next;
            fast = fast.next.next;
        }
        return true;
    }
}