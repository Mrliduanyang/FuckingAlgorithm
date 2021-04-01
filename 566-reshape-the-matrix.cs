public class Solution {
    public int[][] MatrixReshape(int[][] nums, int r, int c) {
                int m = nums.Length;
                int n = nums[0].Length;
                if (m * n != r * c) {
                    return nums;
                }

                int[][] ans = new int[r][];
                for (int i = 0; i < r; i++) {
                    ans[i] = new int[c];
                }
                for (int x = 0; x < m * n; ++x) {
                    ans[x / c][x % c] = nums[x / n][x % n];
                }
                return ans;
    }
}