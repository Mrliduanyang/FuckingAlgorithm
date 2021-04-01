public class Solution {
    public int FindMinArrowShots(int[][] points) {
                if (points.Length == 0) {
                    return 0;
                }
                Array.Sort(points, (a, b) => {
                    return a[1] < b[1] ? -1:1;
                });
                int count = 1;
                int end = points[0][1];
                foreach (var point in points) {
                    var start = point[0];
                    if (start > end) {
                        count++;
                        end = point[1];
                    }
                }
                return count;
    }
}