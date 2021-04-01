public class Solution {
    public bool CheckStraightLine(int[][] coordinates) {
        int deltaX = coordinates[0][0], deltaY = coordinates[0][1];
        var n = coordinates.Length;
        for (var i = 0; i < n; i++) {
            coordinates[i][0] -= deltaX;
            coordinates[i][1] -= deltaY;
        }

        int A = coordinates[1][1], B = -coordinates[1][0];
        for (var i = 2; i < n; i++) {
            int x = coordinates[i][0], y = coordinates[i][1];
            if (A * x + B * y != 0) return false;
        }

        return true;
    }
}