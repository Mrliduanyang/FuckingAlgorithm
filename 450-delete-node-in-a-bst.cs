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
    public TreeNode DeleteNode(TreeNode root, int key) {
        int Successor(TreeNode node) {
            node = node.right;
            while (node.left != null) node = node.left;
            return node.val;
        }

        int Predecessor(TreeNode node) {
            node = node.left;
            while (node.right != null) node = node.right;
            return node.val;
        }

        TreeNode Helper(TreeNode node) {
            // 递归结束条件
            if (node == null) return null;
            // 递归右子树
            if (key > node.val) {
                node.right = Helper(node.right);
            }
            // 递归左子树
            else if (key < node.val) {
                node.left = Helper(node.left);
            }
            // 定位到删除节点
            else {
                // 叶子节点，删除即可
                if (node.left == null && node.right == null) {
                    node = null;
                }
                // 有右子树，用后继几点
                else if (node.right != null) {
                    node.val = Successor(node);
                    key = node.val;
                    node.right = Helper(node.right);
                }
                else {
                    node.val = Predecessor(node);
                    key = node.val;
                    node.left = Helper(node.left);
                }
            }

            return node;
        }

        return Helper(root);
    }
}