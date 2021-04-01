public class Solution {
    public bool Exist(char[][] board, string word) {
                               int h = board.Length;
                int w = board[0].Length;
                var directions = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] {-1, 0 } };
                bool[, ] vis = new bool[h, w];

                bool Helper(int i, int j, int idx) {
                    if (board[i][j] != word[idx]) {
                        return false;
                    } else if (idx == word.Length - 1) {
                        return true;
                    }
                    // 回溯的选择
                    vis[i, j] = true;
                    bool res = false;
                    foreach (var direction in directions) {
                        int tx = i + direction[0], ty = j + direction[1];
                        if (tx >= 0 && tx < h && ty >= 0 && ty < w) {
                            if (!vis[tx, ty]) {
                                bool flag = Helper(tx, ty, idx + 1);
                                if (flag) {
                                    res = true;
                                    break;
                                }
                            }
                        }
                    }
                    vis[i, j] = false;
                    return res;
                }

                for (int i = 0; i < h; i++) {
                    for (int j = 0; j < w; j++) {
                        bool flag = Helper(i, j, 0);
                        if (flag) {
                            return true;
                        }
                    }
                }
                return false;
    }
}