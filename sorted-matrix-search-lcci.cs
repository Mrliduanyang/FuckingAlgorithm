public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        var m = matrix.GetLength(0);
        var n = matrix.GetLength(1);
        int i = m - 1, j = 0;
        while (i >= 0 && j < n) {
            if (matrix[i, j] < target) ++j;
            else if (matrix[i, j] > target) --i;
            else return true;
        }

        return false;
    }
}