public class Solution {
    public int[][] MatrixReshape(int[][] nums, int r, int c) {
        var m = nums.Length;
        var n = nums[0].Length;
        if (m * n != r * c) return nums;

        var ans = new int[r][];
        for (var i = 0; i < r; i++) ans[i] = new int[c];
        for (var x = 0; x < m * n; ++x) ans[x / c][x % c] = nums[x / n][x % n];
        return ans;
    }
}