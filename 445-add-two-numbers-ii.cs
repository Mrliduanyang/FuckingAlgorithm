/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
                var stack1 = new Stack<int>();
                var stack2 = new Stack<int>();
                while (l1 != null) {
                    stack1.Push(l1.val);
                    l1 = l1.next;
                }
                while (l2 != null) {
                    stack2.Push(l2.val);
                    l2 = l2.next;
                }
                int carry = 0;
                ListNode ans = null;
                while (stack1.Count != 0 || stack2.Count != 0 || carry != 0) {
                    var a = stack1.Count != 0 ? stack1.Pop() : 0;
                    var b = stack2.Count != 0 ? stack2.Pop() : 0;
                    int cur = a + b + carry;
                    carry = cur / 10;
                    cur %= 10;
                    var curNode = new ListNode(cur);
                    curNode.next = ans;
                    ans = curNode;
                }
                return ans;
    }
}