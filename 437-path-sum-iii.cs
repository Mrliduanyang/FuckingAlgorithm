using System.Collections.Generic;

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
    public int PathSum(TreeNode root, int targetSum) {
        var prefixSum = new Dictionary<int, int>();
        prefixSum[0] = 1;

        int Helper(TreeNode node, int sum) {
            if (node == null) return 0;
            var res = 0;
            sum += node.val;
            res += prefixSum.GetValueOrDefault(sum - targetSum, 0);

            prefixSum[sum] = prefixSum.GetValueOrDefault(sum, 0) + 1;

            res += Helper(node.left, sum);
            res += Helper(node.right, sum);

            prefixSum[sum]--;
            return res;
        }

        return Helper(root, 0);
    }
}