public class Solution {
            public bool SearchMatrix(int[][] matrix, int target) {
                int m = matrix.Length;
                if (m == 0) return false;
                int n = matrix[0].Length;

                // 二分查找
                int left = 0, right = m * n - 1;
                int pivotIdx, pivotValue;
                while (left <= right) {
                    pivotIdx = (left + right) / 2;
                    pivotValue = matrix[pivotIdx / n][pivotIdx % n];
                    if (target == pivotValue) {
                        return true;
                    } else {
                        if (target < pivotValue) right = pivotIdx - 1;
                        else left = pivotIdx + 1;
                    }
                }
                return false;
            }
}