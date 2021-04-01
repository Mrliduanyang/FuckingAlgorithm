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
    public int[] FindMode(TreeNode root) {
        var res = new List<int>();
        int cur = 0, count = 0, maxCount = int.MinValue;

        void Helper(TreeNode root) {
            if (root == null) return;
            Helper(root.left);
            Update(root.val);
            Helper(root.right);
        }

        void Update(int x) {
            if (x == cur) {
                count++;
            }
            else {
                cur = x;
                count = 1;
            }

            if (count == maxCount) res.Add(cur);
            if (count > maxCount) {
                maxCount = count;
                res.Clear();
                res.Add(cur);
            }
        }

        Helper(root);
        return res.ToArray();
    }
}