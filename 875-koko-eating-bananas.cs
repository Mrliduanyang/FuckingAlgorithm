using System;
using System.Linq;

public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        var left = 1;
        var right = piles.Max();
        while (left < right) {
            var mid = left + (right - left) / 2;
            var need = piles.Sum(pile => (pile - 1) / mid + 1);

            if (need <= h) {
                right = mid;
            }
            else {
                left = mid + 1;
            }
        }

        return left;
    }
}