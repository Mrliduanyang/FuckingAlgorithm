public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        var res = new List<IList<int>>();
        var path = new List<int> {0};
        var n = graph.Length;

        void Helper(int begin) {
            if (begin == n - 1) {
                res.Add(path.ToList());
                return;
            }

            foreach (var node in graph[begin]) {
                path.Add(node);
                Helper(node);
                path.RemoveAt(path.Count - 1);
            }
        }

        Helper(0);
        return res;
    }
}