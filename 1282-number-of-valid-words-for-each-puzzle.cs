public class Solution {
    public IList<int> FindNumOfValidWords(string[] words, string[] puzzles) {
        var res = new List<int>();
        var wordsSummary = new int[words.Length];

        // 用int中的26位标记谜底a-z是否出现过
        for (var i = 0; i < words.Length; i++)
            foreach (var c in words[i])
                wordsSummary[i] |= 1 << (c - 'a');

        for (var i = 0; i < puzzles.Length; i++) {
            int puzzleSummary = 0, count = 0;
            // 用同上方法计算谜面
            foreach (var c in puzzles[i]) puzzleSummary |= 1 << (c - 'a');

            for (var j = 0; j < words.Length; j++)
                if ((puzzleSummary | wordsSummary[j]) == puzzleSummary &&
                    ((1 << (puzzles[i][0] - 'a')) | wordsSummary[j]) == wordsSummary[j])
                    count++;
            res.Add(count);
        }

        return res;
    }
}