public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var res = new List<IList<int>>();

        if (k <= 0 || n < k) return res;
        var path = new List<int>();
        Helper(n, k, 1, path, res);
        return res;
    }

    private void Helper(int n, int k, int begin, List<int> path, List<IList<int>> res) {
        if (path.Count == k) {
            res.Add(new List<int>(path));
            return;
        }

        for (var i = begin; i <= n; i++) {
            path.Add(i);
            Helper(n, k, i + 1, path, res);
            path.RemoveAt(path.Count - 1);
        }
    }
}