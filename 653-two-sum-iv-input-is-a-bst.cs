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
    public bool FindTarget(TreeNode root, int k) {
        var res = new List<int>();
                var stack = new Stack<TreeNode>();
                // root为null并且栈空，结束
                while (root != null || stack.Count != 0) {
                    while (root != null) {
                        stack.Push(root);
                        root = root.left;
                    }
                    root = stack.Pop();
                    res.Add(root.val);
                    root = root.right;
                }
                int left = 0, right = res.Count - 1;
                while (left < right) {
                    int sum = res[left] + res[right];
                    if (sum == k)
                        return true;
                    if (sum < k)
                        left++;
                    else
                        right--;
                }
                return false;
    }
}