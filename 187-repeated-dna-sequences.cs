public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        var res = new List<string>();
        if (s.Length < 10) return res;
        var dict = new Dictionary<string, int>();
        for (var i = 0; i <= s.Length - 10; i++) {
            var segment = s.Substring(i, 10);
            dict[segment] = dict.GetValueOrDefault(segment, 0) + 1;
        }

        foreach (var (key, val) in dict)
            if (val >= 2)
                res.Add(key);
        return res;
    }
}