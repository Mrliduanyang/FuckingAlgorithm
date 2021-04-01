public class Solution {
    public int Candy(int[] ratings) {
        var n = ratings.Length;
        var left = new int[n];
        for (var i = 0; i < n; i++)
            if (i > 0 && ratings[i] > ratings[i - 1])
                left[i] = left[i - 1] + 1;
            else
                left[i] = 1;
        int right = 0, ret = 0;
        for (var i = n - 1; i >= 0; i--) {
            if (i < n - 1 && ratings[i] > ratings[i + 1])
                right++;
            else
                right = 1;
            ret += Math.Max(left[i], right);
        }

        return ret;
    }
}