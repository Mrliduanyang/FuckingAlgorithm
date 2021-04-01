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
    public int SumRootToLeaf(TreeNode root) {
        var res = new List<int>();
        var path = new List<int>();

        void Helper(TreeNode root) {
            if (root == null) return;
            path.Add(root.val);
            if (root.left == null && root.right == null) {
                var tmp = 0;
                foreach (var x in path) tmp = (tmp << 1) + x;
                res.Add(tmp);
            }

            Helper(root.left);
            Helper(root.right);
            path.RemoveAt(path.Count - 1);
        }

        Helper(root);
        return res.Sum();
    }
}