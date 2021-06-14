﻿/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is lower than the guess number
 *			      1 if num is higher than the guess number
 *               otherwise return 0
 * int guess(int num);
 */
public class Solution : GuessGame {
    public int GuessNumber(int n) {
        int left = 1, right = n;
        while (left < right) {
            var mid = left + (right - left) / 2;
            if (guess(mid) <= 0) {
                right = mid;
            }
            else {
                left = mid + 1;
            }
        }

        return left;
    }
}