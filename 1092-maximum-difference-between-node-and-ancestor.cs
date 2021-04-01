/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * public int val;
 * public TreeNode left;
 * public TreeNode right;
 * public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
public class Solution {
    public int MaxAncestorDiff(TreeNode root) {
        // var root = new TreeNode(12);
        if (root == null) return 0;
        var res = int.MinValue;

        (int, int) Helper(TreeNode root) {
            if (root == null) return (100001, -1);
            var curVal = root.val;
            var (lMin, lMax) = Helper(root.left);
            var (rMin, rMax) = Helper(root.right);
            lMin = lMin == 100001 ? curVal : lMin;
            lMax = lMax == -1 ? curVal : lMax;
            rMin = rMin == 100001 ? curVal : rMin;
            rMax = rMax == -1 ? curVal : rMax;
            var curMin = Math.Min(lMin, rMin);
            var curMax = Math.Max(lMax, rMax);
            res = Math.Max(res, Math.Max(Math.Abs(curVal - curMin), Math.Abs(curVal - curMax)));
            return (Math.Min(curVal, curMin), Math.Max(curVal, curMax));
        }

        Helper(root);
        return res;
    }
}