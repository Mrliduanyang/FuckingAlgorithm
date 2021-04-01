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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return build(preorder, 0, preorder.Length - 1,
            inorder, 0, inorder.Length - 1);
    }

    private TreeNode build(int[] preorder, int preStart, int preEnd,
        int[] inorder, int inStart, int inEnd) {
        if (preStart > preEnd) return null;
        // root 节点对应的值就是前序遍历数组的第一个元素
        var rootVal = preorder[preStart];
        // rootVal 在中序遍历数组中的索引
        var index = 0;
        for (var i = inStart; i <= inEnd; i++)
            if (inorder[i] == rootVal) {
                index = i;
                break;
            }

        var leftSize = index - inStart;

        // 先构造出当前根节点
        TreeNode root = new TreeNode(rootVal);
        // 递归构造左右子树
        root.left = build(preorder, preStart + 1, preStart + leftSize,
            inorder, inStart, index - 1);

        root.right = build(preorder, preStart + leftSize + 1, preEnd,
            inorder, index + 1, inEnd);
        return root;
    }
}