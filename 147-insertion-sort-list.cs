/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
public ListNode InsertionSortList(ListNode head)
{
               if(head == null){
                   return head;
               }
               var dummy = new ListNode(0);
               dummy.next = head;
               var last = head;
               var cur = head.next;
               while(cur != null){
                   if(last.val <= cur.val){
                       last = last.next;
                   }else{
                       var prev = dummy;
                       while(prev.next.val <= cur.val){
                           prev =prev.next;
                       }
                       last.next = cur.next;
                       cur.next = prev.next;
                       prev.next = cur;
                   }
                   cur = last.next;
               }
               return dummy.next;
}

}