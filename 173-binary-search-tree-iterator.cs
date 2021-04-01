/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int x) { val = x; }
 * }
 */
public class BSTIterator {
    private int index;
    private List<int> nodesSorted;

    public BSTIterator(TreeNode root) {
        nodesSorted = new List<int>();
        index = -1;
        _inorder(root);
    }

    private void _inorder(TreeNode root) {
        if (root == null) return;
        _inorder(root.left);
        nodesSorted.Add(root.val);
        _inorder(root.right);
    }

    public int Next() {
        return nodesSorted[++index];
    }

    public bool HasNext() {
        return index + 1 < nodesSorted.Count;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */