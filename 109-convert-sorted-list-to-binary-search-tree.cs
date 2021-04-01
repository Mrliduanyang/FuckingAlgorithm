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
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode SortedListToBST(ListNode head) {
                        ListNode GetMedian(ListNode left, ListNode right){
                    var slow = left;
                    var fast = left;
                    while(fast != right && fast.next != right){
                        left = left.next;
                        fast = fast.next;
                        fast = fast.next;
                    }
                    return left;
                }
                TreeNode Helper(ListNode left, ListNode right){
                    if(left == right){
                        return null;
                    }
                    var mid = GetMedian(left, right);
                    var root = new TreeNode(mid.val);
                    root.left = Helper(left, mid);
                    root.right = Helper(mid.next, right);
                    return root;
                }

                return Helper(head, null);
    }
}