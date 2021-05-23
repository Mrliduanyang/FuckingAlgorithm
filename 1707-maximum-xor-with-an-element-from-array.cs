using System;

public class Solution {
    public int[] MaximizeXor(int[] nums, int[][] queries) {
        Array.Sort(nums);
        int numQ = queries.Length;
        Tuple<int, int, int>[] newQueries = new Tuple<int, int, int>[numQ];
        for (int i = 0; i < numQ; ++i) {
            newQueries[i] = new Tuple<int, int, int>(queries[i][0], queries[i][1], i);
        }

        Array.Sort<Tuple<int, int, int>>(newQueries,
            delegate(Tuple<int, int, int> query1, Tuple<int, int, int> query2) { return query1.Item2 - query2.Item2; }
        );

        int[] ans = new int[numQ];
        Trie trie = new Trie();
        int idx = 0, n = nums.Length;
        foreach (Tuple<int, int, int> query in newQueries) {
            int x = query.Item1, m = query.Item2, qid = query.Item3;
            while (idx < n && nums[idx] <= m) {
                trie.Insert(nums[idx]);
                ++idx;
            }

            if (idx == 0) {
                // 字典树为空
                ans[qid] = -1;
            }
            else {
                ans[qid] = trie.GetMaxXor(x);
            }
        }

        return ans;
    }
}

class Trie {
    const int L = 30;
    Trie[] children = new Trie[2];

    public void Insert(int val) {
        Trie node = this;
        for (int i = L - 1; i >= 0; --i) {
            int bit = (val >> i) & 1;
            if (node.children[bit] == null) {
                node.children[bit] = new Trie();
            }

            node = node.children[bit];
        }
    }

    public int GetMaxXor(int val) {
        int ans = 0;
        Trie node = this;
        for (int i = L - 1; i >= 0; --i) {
            int bit = (val >> i) & 1;
            if (node.children[bit ^ 1] != null) {
                ans |= 1 << i;
                bit ^= 1;
            }

            node = node.children[bit];
        }

        return ans;
    }
}