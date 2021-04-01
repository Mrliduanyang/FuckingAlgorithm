/**
 * Definition for singly-linked list.
 * public class ListNode {
 * public int val;
 * public ListNode next;
 * public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        var dict = new Dictionary<ListNode, bool>();
        while (headA != null) {
            dict[headA] = true;
            headA = headA.next;
        }

        while (headB != null)
            if (dict.ContainsKey(headB))
                return headB;
            else
                headB = headB.next;
        return null;
    }
}