public class Solution {
    public int NumberOfBoomerangs(int[][] points) {
        var res = 0;
        foreach (var point in points) {
            var dict = new Dictionary<int, int>();
            foreach (var targetPoint in points) {
                var dx = point[0] - targetPoint[0];
                var dy = point[1] - targetPoint[1];
                var dis = dx * dx + dy * dy;
                dict[dis] = dict.GetValueOrDefault(dis, 0) + 1;
            }

            foreach (var (key, value) in dict) res += value * (value - 1);
        }

        return res;
    }
}