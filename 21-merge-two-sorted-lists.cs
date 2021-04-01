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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        var dummy = new ListNode();
        var head = dummy;
        while(l1 != null && l2 != null){
            if(l1.val <= l2.val ) {
                head.next = l1;
                l1 = l1.next;
            }else {
                head.next = l2;
                l2 = l2.next;
            }
            head = head.next;
        }
        if(l1 != null) head.next = l1;
        if(l2 != null) head.next = l2;
        return dummy.next;
    }
}