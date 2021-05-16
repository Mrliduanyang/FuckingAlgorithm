using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<string> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        var res = new List<string>();
        if (!wordList.Contains(endWord)) return res;
        var dict = new Dictionary<string, List<string>>();
        foreach (var word in wordList) {
            for (var i = 0; i < beginWord.Length; ++i) {
                var nodeWord = $"{word.Substring(0, i)}*{word.Substring(i + 1)}";
                if (!dict.ContainsKey(nodeWord)) {
                    dict[nodeWord] = new List<string>();
                }

                dict[nodeWord].Add(word);
            }
        }

        var queue = new Queue<List<string>>();
        queue.Enqueue(new List<string> {beginWord});
        while (queue.Count != 0) {
            var cur = queue.Dequeue();
            for (var i = 0; i < beginWord.Length; ++i) {
                var nodeWord = $"{cur.Last().Substring(0, i)}*{cur.Last().Substring(i + 1)}";
                if (dict.ContainsKey(nodeWord)) {
                    foreach (var nextWord in dict[nodeWord]) {
                        var tmp = cur.ToList();
                        tmp.Add(nextWord);
                        if (nextWord == endWord) {
                            return tmp;
                        }

                        queue.Enqueue(tmp);
                    }

                    dict.Remove(nodeWord);
                }
            }
        }

        return res;
    }
}