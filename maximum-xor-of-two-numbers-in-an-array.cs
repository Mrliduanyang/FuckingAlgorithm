using System;

public class Trie {
    public Trie left = null;
    public Trie right = null;
}

public class Solution {
    public int FindMaximumXOR(int[] nums) {
        Trie root = new Trie();
        const int HIGH_BIT = 30;
        var n = nums.Length;
        var x = 0;

        void Add(int num) {
            var cur = root;
            for (var k = HIGH_BIT; k >= 0; --k) {
                var bit = (num >> k) & 1;
                if (bit == 0) {
                    if (cur.left == null) {
                        cur.left = new Trie();
                    }

                    cur = cur.left;
                }
                else {
                    if (cur.right == null) {
                        cur.right = new Trie();
                    }

                    cur = cur.right;
                }
            }
        }

        int Check(int num) {
            var cur = root;
            var x = 0;
            for (var k = HIGH_BIT; k >= 0; --k) {
                var bit = (num >> k) & 1;
                if (bit == 0) {
                    if (cur.right != null) {
                        cur = cur.right;
                        x = x * 2 + 1;
                    }
                    else {
                        cur = cur.left;
                        x *= 2;
                    }
                }
                else {
                    if (cur.left != null) {
                        cur = cur.left;
                        x = x * 2 + 1;
                    }
                    else {
                        cur = cur.right;
                        x *= 2;
                    }
                }
            }

            return x;
        }

        for (var i = 1; i < n; ++i) {
            Add(nums[i - 1]);
            x = Math.Max(x, Check(nums[i]));
        }

        return x;
    }
}