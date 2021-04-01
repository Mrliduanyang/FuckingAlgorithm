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
    public bool IsCompleteTree(TreeNode root) {
                if (root == null) return true;
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                var prev = root;
                while (queue.Count != 0) {
                    var count = queue.Count;
                    for (int i = 0; i < count; i++) {
                        var tmp = queue.Dequeue();
                        if (prev == null && tmp != null) return false;
                        if (tmp != null) {
                            queue.Enqueue(tmp.left);
                            queue.Enqueue(tmp.right);
                        }
                        prev = tmp;
                    }
                }
                return true;
    }
}