public class Solution {
    public int[] FindDiagonalOrder(int[][] matrix) {
        if (matrix.Length == 0) return new int[0];
        var res = new List<int>();
        List<int> Cur = new List<int>();
        var col = matrix.Length;
        var row = matrix[0].Length;

        for (var i = 0; i < col + row - 1; i++) {
            var j = i < row ? 0 : i - row + 1;
            var k = i < row ? i : row - 1;
            while (j < col && k > -1) //遍历对角线
                Cur.Add(matrix[j++][k--]);
            if (i % 2 == 0) Cur.Reverse();
            int[] x = Cur.ToArray();
            for (var l = 0; l < x.Length; l++) res.Add(x[l]);
            Cur.Clear();
        }

        return res.ToArray();
    }
}