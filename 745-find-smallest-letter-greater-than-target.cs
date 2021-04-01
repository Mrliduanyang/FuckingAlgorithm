public class Solution {
    public char NextGreatestLetter(char[] letters, char target) {
        int lo = 0, hi = letters.Length;
        while (lo < hi) {
            var mi = lo + (hi - lo) / 2;
            if (letters[mi] <= target) lo = mi + 1;
            else hi = mi;
        }

        return letters[lo % letters.Length];
    }
}