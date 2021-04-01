/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
//  class Solution {
//     HashMap<Integer,Integer> map = new HashMap<>();
//     int max = 0;
//     public int[] findFrequentTreeSum(TreeNode root) {
//         if(root == null){
//             return new int[0];
//         }
//         findSum(root);
//         ArrayList<Integer> list = new ArrayList<>(); 
//         for(int i : map.keySet()){
//             if(map.get(i) == max){
//                 list.add(i);
//             }
//         }
//         int[] result = new int[list.size()];
//         for(int i = 0; i<result.length; i++){
//             result[i] = list.get(i);
//         }
//         return result;
//     }

//     public int findSum(TreeNode root){
//         if(root == null){
//             return 0;
//         }
//         //计算左子树的和
//         int left = findSum(root.left);
//         //计算右子树的和
//         int right = findSum(root.right);
//         //计算当前子树的和
//         int sum = root.val + left + right;
//         //将结果放入HashMap中，并计算出出现的最多次数
//         map.put(sum,map.getOrDefault(sum,0)+1);
//         max = Math.max(max,map.get(sum));
//         return sum;
//     }
// }


public class Solution {
    Dictionary<int, int> map = new Dictionary<int, int>();
    int max = 0;
    public int[] FindFrequentTreeSum(TreeNode root) {
        if (root == null) return new int[] { };

                Helper(root);

                var tmp = new List<int>();
                foreach (var key in map.Keys) {
                    if (map[key] == max) {
                        tmp.Add(key);
                    }
                }
                return tmp.ToArray();
    }
    public int Helper(TreeNode root) {
                    if (root == null) return 0;
                    int left = Helper(root.left);
                    int right = Helper(root.right);
                    int sum = root.val + left + right;
                                        if (!map.ContainsKey(sum)) {
                        map.Add(sum, 0);
                    } else {
                        map[sum] += 1;
                    }
                    max = Math.Max(max, map[sum]);
                    return sum;
                }
    

}