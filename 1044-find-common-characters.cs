public class Solution {
    public IList<string> CommonChars(string[] A) {
        var minFreq = new int[26];
        Array.Fill(minFreq, int.MaxValue);

        foreach (var str in A) {
            var freq = new int[26];
            foreach (var ch in str) freq[ch - 'a']++;
            for (var i = 0; i < 26; i++) minFreq[i] = Math.Min(freq[i], minFreq[i]);
        }

        var ans = new List<string>();
        for (var i = 0; i < 26; i++)
        for (var j = 0; j < minFreq[i]; j++)
            ans.Add(((char) ('a' + i)).ToString());
        return ans;
    }
}