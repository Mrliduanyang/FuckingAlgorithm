using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    public List<IList<string>> GroupAnagrams(string[] strs) {
        var dict = new Dictionary<string, List<string>>();
        foreach (var str in strs) {
            var count = new int[26];
            foreach (var ch in str) {
                count[ch - 'a']++;
            }

            var sb = new StringBuilder();
            for (var i = 0; i < 26; ++i) {
                if (count[i] > 0) {
                    sb.Append('a' + i);
                    sb.Append(count[i]);
                }
            }

            var key = sb.ToString();
            if (!dict.ContainsKey(key)) {
                dict[key] = new List<string>();
            }

            dict[key].Add(str);
        }

        return new List<IList<string>>(dict.Values);
    }
}