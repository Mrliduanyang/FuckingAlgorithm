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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        return build(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
    }

    private TreeNode build(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd) {
        if (inStart > inEnd) return null;
        // root 节点对应的值就是后序遍历数组的最后一个元素
        var rootVal = postorder[postEnd];
        // rootVal 在中序遍历数组中的索引
        var index = 0;
        for (var i = inStart; i <= inEnd; i++)
            if (inorder[i] == rootVal) {
                index = i;
                break;
            }

        // 左子树的节点个数
        var leftSize = index - inStart;
        TreeNode root = new TreeNode(rootVal);
        // 递归构造左右子树
        root.left = build(inorder, inStart, index - 1,
            postorder, postStart, postStart + leftSize - 1);

        root.right = build(inorder, index + 1, inEnd,
            postorder, postStart + leftSize, postEnd - 1);
        return root;
    }
}