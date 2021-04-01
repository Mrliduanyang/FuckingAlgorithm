/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode RemoveElements(ListNode head, int val) {
                var dummy = new ListNode();
                dummy.next = head;
                var prev = dummy;
                var cur = head;
                while(cur != null){
                    if(cur.val == val){
                        prev.next = cur.next;
                    }else{
                        prev = cur;
                    }
                    cur = cur.next;
                }
                return dummy.next;
    }
}