/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

                public string serialize(TreeNode root) {
                    if (root == null) return string.Empty;

                    var res = new List<string>();
                    void Helper(TreeNode node) {
                        if (node == null) {
                            res.Add("null");
                        } else {
                            res.Add(node.val.ToString());
                            Helper(node.left);
                            Helper(node.right);
                        }
                    }
                    Helper(root);
                    return string.Join(",", res);
                }

                public TreeNode deserialize(string data) {
                    if (data == "") return null;
                    string[] nodes = data.Split(',');
                    int idx = 0;
                    TreeNode Helper() {
                        if (nodes[idx] == "null"){
                            return null;
                        }

                        var root = new TreeNode(int.Parse(nodes[idx]));
                        ++idx;
                        root.left = Helper();
                        ++idx;
                        root.right = Helper();
                        return root;
                    }
                    return Helper();
                }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));