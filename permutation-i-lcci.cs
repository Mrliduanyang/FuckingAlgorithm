using System.Collections.Generic;

public class Solution {
    public string[] Permutation(string S) {
        var res = new List<string>();
        var path = new List<char>();

        void Helper() {
            if (path.Count == S.Length) {
                res.Add(string.Join("", path));
                return;
            }

            foreach (var ch in S) {
                if (path.Contains(ch)) continue;
                path.Add(ch);
                Helper();
                path.RemoveAt(path.Count - 1);
            }
        }

        Helper();
        return res.ToArray();
    }
}