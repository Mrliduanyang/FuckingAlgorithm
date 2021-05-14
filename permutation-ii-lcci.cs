using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string[] Permutation(string S) {
        var ss = S.ToArray();
        var res = new List<string>();
        var path = new List<char>();
        var vis = new bool[ss.Length];
        Array.Sort(ss);

        void Helper(int idx) {
            if (idx == ss.Length) {
                res.Add(string.Join("", path));
                return;
            }

            for (var i = 0; i < ss.Length; ++i) {
                if (vis[i] || i > 0 && ss[i] == ss[i - 1] && !vis[i - 1]) continue;
                path.Add(ss[i]);
                vis[i] = true;
                Helper(idx + 1);
                vis[i] = false;
                path.RemoveAt(idx);
            }
        }

        Helper(0);
        return res.ToArray();
    }
}