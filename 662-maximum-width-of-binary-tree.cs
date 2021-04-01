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
    public int WidthOfBinaryTree(TreeNode root) {
                        var queue = new Queue<AnnotatedNode>();
                queue.Enqueue(new AnnotatedNode(root, 0, 0));
                int currDepth = 0, left = 0, ans = 0;
                while (queue.Count != 0) {
                    var tmp = queue.Dequeue();
                    if (tmp.node != null) {
                        queue.Enqueue(new AnnotatedNode(tmp.node.left, tmp.depth + 1, tmp.pos * 2));
                        queue.Enqueue(new AnnotatedNode(tmp.node.right, tmp.depth + 1, tmp.pos * 2 + 1));
                        if (currDepth != tmp.depth) {
                            currDepth = tmp.depth;
                            left = tmp.pos;
                        }
                        ans = Math.Max(ans, tmp.pos - left + 1);
                    }
                }
                return ans;
    }
}

            class AnnotatedNode {
                public TreeNode node;
                public int depth, pos;
                public AnnotatedNode(TreeNode n, int d, int p) {
                    node = n;
                    depth = d;
                    pos = p;
                }
            }