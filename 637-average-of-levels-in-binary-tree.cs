/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<double> AverageOfLevels(TreeNode root) {
                var res = new List<double>();
                if (root == null) return res;
                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                while (queue.Count != 0) {
                    var count = queue.Count;
                    var level = new List<int>();
                    for (int i = 0; i < count; i++) {
                        var tmp = queue.Dequeue();
                        level.Add(tmp.val);
                        if(tmp.left != null) queue.Enqueue(tmp.left);
                        if(tmp.right != null) queue.Enqueue(tmp.right);
                    }
                    res.Add(level.Average());
                }
                return res;
    }
}