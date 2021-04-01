public class Solution {
    public string FrequencySort(string s) {
        var res = new StringBuilder();
        var dict = new Dictionary<char, int>();
        foreach (var ch in s) dict[ch] = dict.GetValueOrDefault(ch, 0) + 1;
        var tmp = dict.OrderByDescending(x => x.Value);
        foreach (var (key, val) in tmp)
            for (var i = 0; i < val; i++)
                res.Append(key);
        return res.ToString();
    }
}