using System.Linq;

public class Solution {
    public int ShipWithinDays(int[] weights, int D) {
        var left = weights.Max();
        var right = weights.Sum();
        while (left < right) {
            var mid = left + (right - left) / 2;
            int need = 1, cur = 0;
            foreach (var weight in weights) {
                if (cur + weight > mid) {
                    ++need;
                    cur = 0;
                }

                cur += weight;
            }

            if (need <= D) {
                right = mid;
            }
            else {
                left = mid + 1;
            }
        }

        return left;
    }
}