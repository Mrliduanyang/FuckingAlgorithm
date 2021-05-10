using System.Collections.Generic;
using System.Linq;

public class Solution {
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        void Helper(TreeNode node, IList<int> seq) {
            if (node.left == null && node.right == null) {
                seq.Add(node.val);
            }
            else {
                if (node.left != null) {
                    Helper(node.left, seq);
                }

                if (node.right != null) {
                    Helper(node.right, seq);
                }
            }
        }

        var seq1 = new List<int>();
        if (root1 != null) {
            Helper(root1, seq1);
        }

        var seq2 = new List<int>();
        if (root2 != null) {
            Helper(root2, seq2);
        }

        return seq1.SequenceEqual(seq2);
    }
}