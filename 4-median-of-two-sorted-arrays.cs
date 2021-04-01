public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;
        var len = m + n;

        int Helper(int k) {
            int idx1 = 0, idx2 = 0;
            while (true) {
                if (idx1 == m) return nums2[idx2 + k - 1];
                if (idx2 == n) return nums1[idx1 + k - 1];
                if (k == 1) return Math.Min(nums1[idx1], nums2[idx2]);
                var half = k / 2;
                var newIdx1 = Math.Min(idx1 + half, m) - 1;
                var newIdx2 = Math.Min(idx2 + half, n) - 1;
                int pivot1 = nums1[newIdx1], pivot2 = nums2[newIdx2];
                if (pivot1 <= pivot2) {
                    k -= newIdx1 - idx1 + 1;
                    idx1 = newIdx1 + 1;
                }
                else {
                    k -= newIdx2 - idx2 + 1;
                    idx2 = newIdx2 + 1;
                }
            }
        }

        if (len % 2 == 1) {
            var mid = len / 2;
            var median = Helper(mid + 1);
            return median;
        }
        else {
            int mid1 = len / 2 - 1, mid2 = len / 2;
            var median = (Helper(mid1 + 1) + Helper(mid2 + 1)) / 2.0;
            return median;
        }
    }
}