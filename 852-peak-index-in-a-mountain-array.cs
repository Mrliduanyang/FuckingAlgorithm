public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        var n = arr.Length;
        int left = 0, right = n - 1;
        while (left < right) {
            var mid = left + (right - left) / 2;
            if (arr[mid] > arr[mid + 1]) {
                right = mid;
            }
            else {
                left = mid + 1;
            }
        }

        return left;
    }
}