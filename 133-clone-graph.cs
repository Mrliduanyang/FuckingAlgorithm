/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;
    
    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }
    
    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if(node == null){
            return node;
        }
        var vis = new Dictionary<Node, Node>();
        var queue = new Queue<Node>();

        vis[node] = new Node(node.val, new List<Node>());
        queue.Enqueue(node);

        while(queue.Count != 0){
            var n = queue.Dequeue();
            foreach(var item in n.neighbors){
                if(!vis.ContainsKey(item)){
                    vis[item] = new Node(item.val, new List<Node>());
                    queue.Enqueue(item);
                }
                vis[n].neighbors.Add(vis[item]);
            }
        }
        return vis[node];
    }
}