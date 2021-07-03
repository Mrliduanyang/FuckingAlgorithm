using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public string FrequencySort(string s) {
        var dict = new Dictionary<char, int>();
        foreach (var ch in s) dict[ch] = dict.GetValueOrDefault(ch, 0) + 1;
        var maxFreq = dict.Values.Max();
        var buckets = new StringBuilder[maxFreq + 1];
        for (var i = 0; i <= maxFreq; ++i) {
            buckets[i] = new StringBuilder();
        }

        foreach (var (key, val) in dict) {
            for (var i = 0; i < val; ++i) {
                buckets[val].Append(key);
            }
        }

        var res = new StringBuilder();
        for (var i = maxFreq; i > 0; --i) {
            var bucket = buckets[i];
            res.Append(bucket.ToString());
        }

        return res.ToString();
    }
}