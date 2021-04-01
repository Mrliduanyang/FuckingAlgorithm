public class Solution {
    public void SetZeroes(int[][] matrix) {
// 用特殊值做标记
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                if(matrix[i][j]==0){
                    for(int m = 0; m < rows; m++){
                        if (matrix[m][j] != 0){
                            matrix[m][j] = int.MaxValue - 10;
                        }
                    }
                    for(int n = 0; n <cols; n++){
                        if(matrix[i][n] != 0){
                            matrix[i][n] = int.MaxValue - 10;
                        }
                    }
                }
            }
        }

        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                if(matrix[i][j]==int.MaxValue - 10){
                    matrix[i][j]=0;
                }
            }
        }
    }
}