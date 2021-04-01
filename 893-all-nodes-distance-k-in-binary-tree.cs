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
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K) {
                        var res = new List<int>();
                void SubtreeAdd(TreeNode node, int dist) {
                    if (node == null) return;
                    if (dist == K)
                        res.Add(node.val);
                    else {
                        SubtreeAdd(node.left, dist + 1);
                        SubtreeAdd(node.right, dist + 1);
                    }
                }

                int Helper(TreeNode node) {
                    if (node == null) return -1;
                    else if (node == target) {
                        SubtreeAdd(node, 0);
                        return 1;
                    } else {
                        int L = Helper(node.left), R = Helper(node.right);
                        if (L != -1) {
                            if (L == K) res.Add(node.val);
                            SubtreeAdd(node.right, L + 1);
                            return L + 1;
                        } else if (R != -1) {
                            if (R == K) res.Add(node.val);
                            SubtreeAdd(node.left, R + 1);
                            return R + 1;
                        } else {
                            return -1;
                        }
                    }
                }
                Helper(root);
                return res;
    }
}