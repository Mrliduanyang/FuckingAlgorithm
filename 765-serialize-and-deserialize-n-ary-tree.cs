/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Codec {
    public string serialize(Node root) {
        if (root == null) return string.Empty;

        var res = new List<string>();

        void Helper(Node node) {
            if (node == null) {
                res.Add("null");
                return;
            }

            res.Add(node.val.ToString());
            res.Add(node.children.Count.ToString());
            foreach (var child in node.children) Helper(child);
        }

        Helper(root);
        return string.Join(",", res);
    }

    public Node deserialize(string data) {
        if (data == "") return null;
        var nodes = data.Split(',');
        var idx = 0;

        Node Helper() {
            if (nodes[idx] == "null") return null;
            var root = new Node(int.Parse(nodes[idx]), new List<Node>());
            var num = int.Parse(nodes[++idx]);
            for (var i = 0; i < num; ++i) {
                ++idx;
                root.children.Add(Helper());
            }

            return root;
        }

        return Helper();
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));