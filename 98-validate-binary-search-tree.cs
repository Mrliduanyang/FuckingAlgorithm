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
    public bool helper(TreeNode rot, int low, int up) {
        //rot为当前节点值，low为子树下限，up为上限
        if (rot == null) return true;


        if (!helper(rot.left, low, rot.val)) //当前为左子树时，无下限，上限为根节点
            return false;
        if (!helper(rot.right, rot.val, up)) //当前为右子树时，无上限，下限为根节点
            return false;


        if (low != -1 && rot.val <= low)
            return false;
        if (up != -1 && rot.val >= up)
            return false;


        return true;
    }

    public bool IsValidBST(TreeNode root) {
        return helper(root, -1, -1);
    }
}