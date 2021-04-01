/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class BSTIterator {
                List<int> nodesSorted;
                int index;

                public BSTIterator(TreeNode root) {
                    this.nodesSorted = new List<int>();
                    this.index = -1;
                    this._inorder(root);
                }

                private void _inorder(TreeNode root) {
                    if (root == null) {
                        return;
                    }
                    this._inorder(root.left);
                    this.nodesSorted.Add(root.val);
                    this._inorder(root.right);
                }

                public int Next() {
                    return this.nodesSorted[(++this.index)];
                }

                public bool HasNext() {
                    return this.index + 1 < this.nodesSorted.Count;
                }
            }

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */