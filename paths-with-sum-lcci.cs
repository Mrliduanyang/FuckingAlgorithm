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
    public int PathSum(TreeNode root, int sum) {
        var prefixSum = new Dictionary<int, int>();
        prefixSum[0] = 1;

        int Helper(TreeNode node, int curSum) {
            if (node == null) return 0;
            var res = 0;
            curSum += node.val;
            res += prefixSum.GetValueOrDefault(curSum - sum, 0);

            prefixSum[curSum] = prefixSum.GetValueOrDefault(curSum, 0) + 1;

            res += Helper(node.left, curSum);
            res += Helper(node.right, curSum);

            prefixSum[curSum]--;
            return res;
        }

        return Helper(root, 0);
    }
}