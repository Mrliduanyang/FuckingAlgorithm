public class Solution {
    public bool[] CanEat(int[] candiesCount, int[][] queries) {
        var n = candiesCount.Length;
        var preSum = new long[n];
        preSum[0] = candiesCount[0];
        for (var i = 1; i < n; ++i) {
            preSum[i] = preSum[i - 1] + candiesCount[i];
        }

        var q = queries.Length;
        var res = new bool[q];
        for (var i = 0; i < q; ++i) {
            var query = queries[i];
            int favoriteType = query[0], favoriteDay = query[1], dailyCap = query[2];
            long x1 = favoriteDay + 1;
            var y1 = (long) x1 * dailyCap;
            var x2 = favoriteType == 0 ? 1 : preSum[favoriteType - 1] + 1;
            var y2 = preSum[favoriteType];

            res[i] = !(x1 > y2 || y1 < x2);
        }

        return res;
    }
}