public TreeNode deserialize(string data) {
    if (string.IsNullOrEmpty(data)) return null;

    string[] nodes = data.Split(',');
    var root = new TreeNode(int.Parse(nodes[0]));
    var queue = new Queue<TreeNode>();
    queue.Enqueue(root);
    int idx = 1;
    while (queue.Count != 0) {
        var node = queue.Dequeue();
        node.left = nodes[idx] == "null" ? null : new TreeNode(int.Parse(nodes[idx]));
        if (node.left != null) {
            queue.Enqueue(node.left);
        }
        idx++;

        node.right = nodes[idx] == "null" ? null : new TreeNode(int.Parse(nodes[idx]));
        if (node.right != null) {
            queue.Enqueue(node.right);
        }
        idx++;
    }
    return root;
}