public class Solution {
    public int LeastBricks(IList<IList<int>> wall) {
        var dict = new Dictionary<int, int>();
        foreach (var row in wall) {
            var sum = 0;
            for (var i = 0; i < row.Count - 1; ++i) {
                sum += row[i];
                dict[sum] = dict.GetValueOrDefault(sum, 0) + 1;
            }
        }

        return dict.Count > 0 ? wall.Count - dict.Values.Max() : wall.Count;
    }
}
