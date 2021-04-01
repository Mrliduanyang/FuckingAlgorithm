/**
 * Definition for singly-linked list.
 * public class ListNode {
 * public int val;
 * public ListNode next;
 * public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    /**
     * @param head The linked list's head.
     * Note that the head is guaranteed to be not null, so it contains at least one node.
     */
    private readonly ListNode _head;

    public Solution(ListNode head) {
        _head = head;
    }

    /**
     * Returns a random node's value.
     */
    public int GetRandom() {
        Random r = new Random();
        int i = 0, res = 0;
        var p = _head;
        while (p != null) {
            // 生成一个[0，i]之间的整数，这个数等于0的概率即是1/i
            if (r.Next(++i) == 0) res = p.val;
            p = p.next;
        }

        return res;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(head);
 * int param_1 = obj.GetRandom();
 */