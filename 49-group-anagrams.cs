public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
var res = new List<IList<string>>();
                if (strs.Length == 0) {
                    return res;
                }
                var dict = new Dictionary<string, List<int>>();
                for (int i = 0; i < strs.Length; i++) {
                    var tmp = string.Join("", strs[i].OrderBy(x => x));
                    if (!dict.ContainsKey(tmp)) {
                        dict[tmp] = new List<int>();
                    }
                    dict[tmp].Add(i);
                }
                foreach (var(_, val) in dict) {
                    var tmp = new List<string>();
                    foreach (var idx in val) {
                        tmp.Add(strs[idx]);
                    }
                    res.Add(tmp);
                }
                return res;
    }
}