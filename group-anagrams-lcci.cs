using System.Collections.Generic;
using System.Linq;

public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        if (strs.Length == 0) {
            return new List<List<string>>();;
        }

        var dict = new Dictionary<string, List<string>>();
        foreach (var str in strs) {
            var tmp = string.Join("", str.OrderBy(x => x));
            if (!dict.ContainsKey(tmp)) {
                dict[tmp] = new List<string>();
            }

            dict[tmp].Add(str);
        }
        
        return dict.Values.ToList();
    }
}
