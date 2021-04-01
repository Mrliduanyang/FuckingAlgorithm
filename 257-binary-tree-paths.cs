/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

using System.Collections.Generic;

public class Solution {
    public IList<string> BinaryTreePaths(TreeNode root) {
        // 深度优先，每个深度遍历的结果就是一个路径
        var paths = new List<string>();
        Helper(root, "", paths);
        return paths;
    }

    public void Helper(TreeNode root, string path, List<string> paths) {
        if (root != null) {
            path += root.val;
            if (root.left == null && root.right == null) {
                // 是叶子节点
                paths.Add(path);
            }
            else {
                path += "->";
                Helper(root.left, path, paths);
                Helper(root.right, path, paths);
            }
        }
    }
}