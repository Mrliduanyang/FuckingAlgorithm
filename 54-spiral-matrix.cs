public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        var res = new List<int>();
        var m = matrix.Length;
        if (m == 0) return res;
        var n = matrix[0].Length;
        // 遍历完一行或者一列后，修改上下左右边界
        int top = 0, bottom = m - 1, left = 0, right = n - 1;
        while (res.Count < m * n) {
            // 遍历顶
            for (var j = left; j <= right; j++) res.Add(matrix[top][j]);
            top++;
            // 遍历右
            for (var i = top; i <= bottom; i++) res.Add(matrix[i][right]);
            right--;
            // 遍历底
            for (var j = right; j >= left; j--) res.Add(matrix[bottom][j]);
            bottom--;
            // 遍历左
            for (var i = bottom; i >= top; i--) res.Add(matrix[i][left]);
            left++;
        }

        return res.GetRange(0, m * n);
    }
}