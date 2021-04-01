public class Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        var A = new double[102, 102];
        A[0, 0] = poured;
        for (var r = 0; r <= query_row; ++r)
        for (var c = 0; c <= r; ++c) {
            var q = (A[r, c] - 1.0) / 2.0;
            if (q > 0) {
                A[r + 1, c] += q;
                A[r + 1, c + 1] += q;
            }
        }

        return Math.Min(1, A[query_row, query_glass]);
    }
}