/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K) {
        var res = new List<int>();

        void AddSubtree(TreeNode node, int dist) {
            if (node == null) return;
            if (dist == K) {
                res.Add(node.val);
            }
            else {
                AddSubtree(node.left, dist + 1);
                AddSubtree(node.right, dist + 1);
            }
        }

        int Helper(TreeNode node) {
            if (node == null) return -1;

            if (node == target) {
                AddSubtree(node, 0);
                return 1;
            }

            int leftDis = Helper(node.left), rightDis = Helper(node.right);
            if (leftDis != -1) {
                if (leftDis == K) {
                    res.Add(node.val);
                }
                else if (leftDis < K) {
                    AddSubtree(node.right, leftDis + 1);
                }

                return leftDis + 1;
            }

            if (rightDis != -1) {
                if (rightDis == K) {
                    res.Add(node.val);
                }
                else if (rightDis < K) {
                    AddSubtree(node.left, rightDis + 1);
                }

                return rightDis + 1;
            }

            return -1;
        }

        Helper(root);
        return res;
    }
}
