public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        var wordDictSet = new HashSet<string>(wordDict);

        var dp = new bool[s.Length + 1];
        dp[0] = true;
        for (var i = 1; i <= s.Length; ++i)
        for (var j = 0; j < i; ++j)
            if (dp[j] && wordDictSet.Contains(s.Substring(j, i - j))) {
                dp[i] = true;
                break;
            }

        return dp[s.Length];
    }
}