/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
            ListNode left;
            public bool IsPalindrome(ListNode head) {
                left = head;
                return Traverse(head);
            }

            public bool Traverse(ListNode right) {
                if (right == null) {
                    return true;
                }
                // 利用后序遍历，通过递归，深入到链表最后一个节点，然后比较right和left。
                // 之后right返回到递归的上一层，相当于右指针左移，left=left.next等于左指针右移，巧妙实现双指针。
                bool res = Traverse(right.next);
                res = res && (left.val == right.val);
                left = left.next;
                return res;
            }
}