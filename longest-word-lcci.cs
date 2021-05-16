using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string LongestWord(string[] words) {
        bool WordBreak(string word) {
            var wordSet = words.ToHashSet();
            wordSet.Remove(word);
            var dp = new bool[word.Length + 1];
            dp[0] = true;
            for (var i = 1; i <= word.Length; ++i) {
                for (var j = 0; j < i; ++j) {
                    if (dp[j] && wordSet.Contains(word.Substring(j, i - j))) {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[word.Length];
        }

        Array.Sort(words);
        var maxLen = words.Select(x => x.Length).Max();
        for (var i = maxLen; i >= 0; --i) {
            foreach (var word in words) {
                if (word.Length == i) {
                    if (WordBreak(word)) {
                        return word;
                    }
                }
            }
        }

        return "";
    }
}