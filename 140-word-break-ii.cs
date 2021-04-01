public class Solution {
    public IList<string> WordBreak(string s, IList<string> wordDict) {
                var map = new Dictionary<int, List<List<string>>>();
                var wordSet = new HashSet<string>(wordDict);
                int len = s.Length;
                List<List<string>> Helper(int idx) {
                    if (!map.ContainsKey(idx)) {
                        var wordBreaks = new List<List<string>>();
                        if (idx == len) {
                            wordBreaks.Add(new List<string>());
                        }
                        for (int i = idx + 1; i <= len; ++i) {
                            var word = s.Substring(idx, i - idx);
                            if (wordSet.Contains(word)) {
                                var nextWordBreaks = Helper(i);
                                foreach (var nextWordBreak in nextWordBreaks) {
                                    var wordBreak = new List<string>(nextWordBreak);
                                    wordBreak.Insert(0, word);
                                    wordBreaks.Add(wordBreak);
                                }
                            }
                        }
                        map[idx] = wordBreaks;
                    }
                    return map[idx];
                }
                var wordBreaks = Helper(0);
                return wordBreaks.Select(x => string.Join(" ", x)).ToList();
    }
}