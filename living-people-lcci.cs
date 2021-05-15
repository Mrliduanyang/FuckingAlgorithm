public class Solution {
    public int MaxAliveYear(int[] birth, int[] death) {
        var n = birth.Length;
        var diffs = new int[102];
        for (var i = 0; i < n; ++i) {
            int x = birth[i] - 1900, y = death[i] - 1900;
            ++diffs[x];
            --diffs[y + 1];
        }

        int sum = 0, max = 0, idx = 0;
        for (var i = 0; i < 101; ++i) {
            sum += diffs[i];
            if (sum > max) {
                max = sum;
                idx = i;
            }
        }

        return idx;
    }
}