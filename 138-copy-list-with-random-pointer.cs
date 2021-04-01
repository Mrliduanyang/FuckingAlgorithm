/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
                        if (head == null) {
                    return null;
                }
                var vis = new Dictionary<Node, Node>();

                Node CloneNode(Node node) {
                    if (node != null) {
                        if (!vis.ContainsKey(node)) {
                            vis[node] = new Node(node.val, null, null);
                        }
                        return vis[node];
                    }
                    return null;
                }

                var old = head;
                var newNode = new Node(old.val);
                vis[old] = newNode;
                while (old != null) {
                    newNode.next = CloneNode(old.next);
                    newNode.random = CloneNode(old.random);
                    old = old.next;
                    newNode = newNode.next;
                }
                return vis[head];
    }
}