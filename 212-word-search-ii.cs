public class Solution {
    public IList<string> FindWords(char[][] board, string[] words) {
                int h = board.Length;
                int w = board[0].Length;
                var directions = new int[][] { new[] { 0, 1 }, new[] { 0, -1 }, new[] { 1, 0 }, new[] { -1, 0 } };
                bool[,] vis = new bool[h, w];

                var res = new HashSet<string>();

                bool Exist(int i, int j, string word) {
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
                                    // 剪枝，找到一个即可返回
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

                    return Helper(i, j, 0);
                }

                for (int i = 0; i < h; i++) {
                    for (int j = 0; j < w; j++) {
                        foreach (var word in words) {
                            if (board[i][j] == word[0]) {
                                if (Exist(i, j, word)) {
                                    res.Add(word);
                                }
                            }
                        }
                    }
                }
                return res.ToList();
    }
}