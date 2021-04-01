public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int X) {
        var n = customers.Length;
        var ans = 0;
        for (var i = 0; i < n; i++)
            if (grumpy[i] == 0) {
                ans += customers[i];
                customers[i] = 0;
            }

        int max = 0, cur = 0;
        for (int i = 0, j = 0; i < n; i++) {
            cur += customers[i];
            if (i - j + 1 > X) cur -= customers[j++];
            max = Math.Max(max, cur);
        }

        return ans + max;
    }
}