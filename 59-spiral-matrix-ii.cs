public class Solution {
    public int[][] GenerateMatrix(int n) {
                int maxNum = n * n;
                int curNum = 0;
                int[][] matrix = new int[n][];
                for (int i = 0; i < n; ++i) {
                    matrix[i] = new int[n];
                }
                int top = 0, bottom = n - 1, left = 0, right = n - 1;
                while (curNum < n * n) {
                    for (int j = left; j <= right; ++j) {
                        matrix[top][j] = ++curNum;
                    }
                    ++top;
                    for (int i = top; i <= bottom; ++i) {
                        matrix[i][right] = ++curNum;
                    }
                    --right;
                    for (int j = right; j >= left; j--) {
                        matrix[bottom][j] = ++curNum;
                    }
                    --bottom;
                    for (int i = bottom; i >= top; i--) {
                        matrix[i][left] = ++curNum;
                    }
                    ++left;
                }
                return matrix;
    }
}