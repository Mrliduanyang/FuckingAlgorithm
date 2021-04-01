/**
 * Definition for singly-linked list.
 * public class ListNode {
 * public int val;
 * public ListNode next;
 * public ListNode(int val=0, ListNode next=null) {
 * this.val = val;
 * this.next = next;
 * }
 * }
 */
public class Solution {
    // 保证每组一次只能有一个在SortedSet中
    public ListNode MergeKLists(ListNode[] lists) {
        // if ListNode a and ListNode b in ListNodeIndex a,b are equal, return the one whose index is smaller, else return whose value is smaller (min-heap/ min priority queue)
        SortedSet<ListNodeIndex> ss = new SortedSet<ListNodeIndex>(Comparer<ListNodeIndex>.Create((a, b) =>
            a.Node.val == b.Node.val ? a.Index - b.Index : a.Node.val - b.Node.val));
        ListNode head = new ListNode(0), p = head;

        for (var i = 0; i < lists.Length; i++)
            if (lists[i] != null)
                ss.Add(new ListNodeIndex(lists[i], i));

        while (ss.Count != 0) {
            // Remove root and add to result set
            ListNodeIndex min = ss.Min;
            ss.Remove(min);
            p.next = min.Node;
            p = p.next;

            // Get a node from 0~k linkedList, add to priority queue. 
            min.Node = min.Node.next;
            if (min.Node != null) ss.Add(min);
        }

        return head.next;
    }

    public class ListNodeIndex {
        public ListNodeIndex(ListNode node, int index) {
            Node = node;
            Index = index;
        }

        public ListNode Node { get; set; }
        public int Index { get; set; }
    }
}