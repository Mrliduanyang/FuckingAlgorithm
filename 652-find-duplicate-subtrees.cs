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
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        var dict = new Dictionary<string, int>();
        var res = new List<TreeNode>();

        string Helper(TreeNode root) {
            if (root == null) return "#";
            var str = $"{root.val},{Helper(root.left)},{Helper(root.right)}";
            dict[str] = dict.GetValueOrDefault(str, 0) + 1;
            // 只在==2时添加一次，之后再出现同样的str，也无需添加
            if (dict[str] == 2) res.Add(root);
            return str;
        }

        Helper(root);
        return res;
    }
}