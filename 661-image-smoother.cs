public class Solution {
    public int[][] ImageSmoother(int[][] M) {
                int R = M.Length, C = M[0].Length;
                var ans = new int[R][];
                for (int r = 0; r < R; ++r) {
                    ans[r] = new int[C];
                    for (int c = 0; c < C; ++c) {
                        int count = 0;
                        for (int nr = r - 1; nr <= r + 1; ++nr) {
                            for (int nc = c - 1; nc <= c + 1; ++nc) {
                                if (0 <= nr && nr < R && 0 <= nc && nc < C) {
                                    ans[r][c] += M[nr][nc];
                                    count++;
                                }
                            }
                        }
                        ans[r][c] /= count;
                    }
                }
                return ans;
    }
}