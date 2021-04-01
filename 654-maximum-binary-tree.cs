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
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
                TreeNode Helper(int[] nums, int lo, int hi) {
                    // 递归base。
                    if (lo > hi) return null;

                    int index = -1, maxVal = int.MinValue;
                    for (int i = lo; i <= hi; i++) {
                        if (maxVal < nums[i]) {
                            maxVal = nums[i];
                            index = i;
                        }
                    }

                    // 递归构造左右子树。
                    TreeNode root = new TreeNode(maxVal);
                    root.left = Helper(nums, lo, index - 1);
                    root.right = Helper(nums, index + 1, hi);

                    return root;
                }

                return Helper(nums, 0, nums.Length - 1);
    }
}