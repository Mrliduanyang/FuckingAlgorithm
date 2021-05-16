using System;
using System.Collections.Generic;

public class Solution {
    public int FindClosest(string[] words, string word1, string word2) {
        var dict = new Dictionary<string, List<int>>();
        for (var i = 0; i < words.Length; ++i) {
            var word = words[i];
            if (!dict.ContainsKey(word)) {
                dict[word] = new List<int>();
            }

            dict[word].Add(i);
        }

        var word1Idxs = dict[word1];
        var word2Idxs = dict[word2];
        int p1 = 0, p2 = 0, res = int.MaxValue;
        while (p1 < word1Idxs.Count && p2 < word2Idxs.Count) {
            res = Math.Min(Math.Abs(word1Idxs[p1] - word2Idxs[p2]), res);
            if (word1Idxs[p1] > word2Idxs[p2]) {
                ++p2;
            }
            else {
                ++p1;
            }
        }

        return res;
    }
}