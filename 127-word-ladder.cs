using System.Collections.Generic;

public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if (!wordList.Contains(endWord)) return 0;

        var len = beginWord.Length;

        var dic = new Dictionary<string, List<string>>(wordList.Count);

        foreach (var item in wordList)
            for (var i = 0; i < len; ++i) {
                var ch = $"{item.Substring(0, i)}*{item.Substring(i + 1)}";

                if (dic.ContainsKey(ch)) dic[ch].Add(item);
                else dic.Add(ch, new List<string> {item});
            }

        Queue<KeyValuePair<string, int>> queue = new Queue<KeyValuePair<string, int>>(wordList.Count);
        queue.Enqueue(new KeyValuePair<string, int>(beginWord, 1));

        while (queue.Count != 0) {
            var point = queue.Dequeue();
            var word = point.Key;
            var count = point.Value;

            for (var i = 0; i < len; ++i) {
                var ch = $"{word.Substring(0, i)}*{word.Substring(i + 1, len - i - 1)}";

                if (dic.ContainsKey(ch)) {
                    foreach (var item in dic[ch]) {
                        if (item == endWord) return ++count;
                        queue.Enqueue(new KeyValuePair<string, int>(item, count + 1));
                    }

                    dic.Remove(ch);
                }
            }
        }

        return 0;
    }
}