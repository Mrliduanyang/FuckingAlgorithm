public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var tmp = new int[m];
        Array.Copy(nums1, tmp, m);
        int i = 0, j = 0, k = 0;
        while (i < m && j < n) nums1[k++] = tmp[i] <= nums2[j] ? tmp[i++] : nums2[j++];
        if (i < m) Array.Copy(tmp, i, nums1, i + j, m + n - i - j);
        if (j < n) Array.Copy(nums2, j, nums1, i + j, m + n - i - j);
    }
}