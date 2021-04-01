public class Solution {
    public int[][] GenerateMatrix(int n) {
        var maxNum = n * n;
        var curNum = 0;
        var matrix = new int[n][];
        for (var i = 0; i < n; ++i) matrix[i] = new int[n];
        int top = 0, bottom = n - 1, left = 0, right = n - 1;
        while (curNum < n * n) {
            for (var j = left; j <= right; ++j) matrix[top][j] = ++curNum;
            ++top;
            for (var i = top; i <= bottom; ++i) matrix[i][right] = ++curNum;
            --right;
            for (var j = right; j >= left; j--) matrix[bottom][j] = ++curNum;
            --bottom;
            for (var i = bottom; i >= top; i--) matrix[i][left] = ++curNum;
            ++left;
        }

        return matrix;
    }
}