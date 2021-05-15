using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string[] TrulyMostPopular(string[] names, string[] synonyms) {
        var parents = new Dictionary<string, string>();
        var counts = new Dictionary<string, int>();

        string Find(string p) {
            return parents[p] == p ? p : parents[p] = Find(parents[p]);
        }

        void Union(string p, string q) {
            var pRoot = Find(p);
            var qRoot = Find(q);
            if (pRoot == qRoot) return;
            if (pRoot.CompareTo(qRoot) < 0) {
                parents[qRoot] = pRoot;
                counts[pRoot] = counts[pRoot] + counts[qRoot];
            }
            else {
                parents[pRoot] = qRoot;
                counts[qRoot] = counts[pRoot] + counts[qRoot];
            }
        }

        int GetCount(string p) {
            var pRoot = Find(p);
            return counts[pRoot];
        }

        foreach (var _ in names) {
            var tmp = _.Split('(');
            var name = tmp[0];
            var count = int.Parse(tmp[1][..^1]);
            parents[name] = name;
            counts[name] = count;
        }

        foreach (var synonym in synonyms) {
            var tmp = synonym.Split(',');
            var p = tmp[0][1..];
            var q = tmp[1][..^1];

            if (!parents.ContainsKey(p)) {
                parents[p] = p;
                counts[p] = 0;
            }

            if (!parents.ContainsKey(q)) {
                parents[q] = q;
                counts[q] = 0;
            }

            Union(p, q);
        }

        var res = new List<string>();
        foreach (var _ in names) {
            var tmp = _.Split('(');
            var name = tmp[0];
            if (name == Find(name)) {
                res.Add($"{name}({counts[name]})");
            }
        }

        return res.ToArray();
    }
}