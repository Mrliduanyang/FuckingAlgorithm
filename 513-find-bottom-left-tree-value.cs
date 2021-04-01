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
    public int FindBottomLeftValue(TreeNode root) {
        Queue<TreeNode> q = new Queue<TreeNode>();
        if(root == null)return -1;
        q.Enqueue(root);
        int res = 0;
        while(q.Count != 0){
            int sz = q.Count;
            for(int i = 0; i < sz ; i++){
                TreeNode cur = q.Dequeue();
                res = cur.val;

                if(cur.right != null){
                    q.Enqueue(cur.right);
                }
                if(cur.left != null){
                    q.Enqueue(cur.left);
                }
            }
        }
        return res;
    }
}
