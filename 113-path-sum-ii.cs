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
    List<IList<int>> res = new List<IList<int>>();
    List<int> path = new List<int>();

    public IList<IList<int>> PathSum(TreeNode root, int sum) {
        // 深度优先，当走到叶子节点，并且sum=0，找到一条路径，反之回溯
        Helper(root, sum);
        return res;
    }

    void Helper(TreeNode root, int sum){
        if (root == null)return;

        path.Add(root.val);
        sum -= root.val;

        if(root.left == null && root.right == null && sum == 0){
            res.Add(new List<int>(path));
        }
        Helper(root.left, sum);
        Helper(root.right, sum);
        path.RemoveAt(path.Count - 1);
    }
}