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
    public string SmallestFromLeaf(TreeNode root) {
                var res = new List<string>();
                var str = new StringBuilder();
                void Helper(TreeNode root) {
                    if (root == null) return;
                    str.Append((char)('a' + root.val));
                    if (root.left == null && root.right == null) {
                        var tmp = new string(str.ToString().Reverse().ToArray());
                        res.Add(tmp);
                    }
                    Helper(root.left);
                    Helper(root.right);
                    str.Remove(str.Length - 1, 1);
                }
                Helper(root);
                return res.Min();
    }
}