public class Solution {
    public int CompareVersion(string version1, string version2) {
        var nums1 = version1.Split('.').Select(x => int.Parse(x)).ToArray();
        var nums2 = version2.Split('.').Select(x => int.Parse(x)).ToArray();
        int m = nums1.Length, n = nums2.Length;
        int i1, i2;
        for (var i = 0; i < Math.Max(m, n); i++) {
            i1 = i < m ? nums1[i] : 0;
            i2 = i < n ? nums2[i] : 0;
            if (i1 != i2) return i1 > i2 ? 1 : -1;
        }

        return 0;
    }
}