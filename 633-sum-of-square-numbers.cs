using System;

public class Solution {
    public bool JudgeSquareSum(int c) {
        var left = 0;
        var right = (int) Math.Sqrt(c);
        while (left <= right) {
            var sum = left * left + right * right;
            if (sum == c) {
                return true;
            }
            else if (sum > c) {
                --right;
            }
            else {
                ++left;
            }
        }

        return false;
    }
}