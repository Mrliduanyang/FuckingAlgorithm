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
    public int Rob(TreeNode root) {
                var memo = new Dictionary<TreeNode, int>();
                // 利用备忘录消除重叠子问题
                int Helper(TreeNode root) {
                    if (root == null) return 0;

                    if (memo.ContainsKey(root)) {
                        return memo[root];
                    }
                    // 抢，然后去下下家
                    int doIt = root.val +
                        (root.left == null ?
                            0 : Helper(root.left.left) + Helper(root.left.right)) +
                        (root.right == null ?
                            0 : Helper(root.right.left) + Helper(root.right.right));
                    // 不抢，然后去下家
                    int dont = Helper(root.left) + Helper(root.right);

                    int res = Math.Max(doIt, dont);
                    memo[root] = res;
                    return res;
                }
                return Helper(root);
    }
}