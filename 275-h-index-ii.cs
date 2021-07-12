public class Solution {
    public int HIndex(int[] citations) {
        var n = citations.Length;
        var left = 0;
        var right = n;
        while (left < right) {
            var mid = left + (right - left) / 2;
            if (citations[mid] >= n - mid) {
                right = mid;
            }
            else {
                left = mid + 1;
            }
        }

        return n - left;
    }
}