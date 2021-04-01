public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
if (image[sr][sc] == newColor) return image;
                int[] dx = { 0, 1, 0, -1 };
                int[] dy = { 1, 0, -1, 0 };
                int m = image.Length, n = image[0].Length, oldColor = image[sr][sc];
                var stack = new Stack<Tuple<int, int>>();
                stack.Push(new Tuple<int, int>(sr, sc));
                while (stack.Count != 0) {
                    var(curRow, curCol) = stack.Pop();
                    image[curRow][curCol] = newColor;
                    for (int i = 0; i < 4; i++) {
                        var tx = curRow + dx[i];
                        var ty = curCol + dy[i];
                        if (tx >= 0 && tx < m && ty >= 0 && ty < n && image[tx][ty] == oldColor) {
                            stack.Push(new Tuple<int, int>(tx, ty));
                        }
                    }
                }
                return image;
    }
}