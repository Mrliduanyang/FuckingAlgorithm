public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        Array.Sort(nums1);
        Array.Sort(nums2);
        if (nums1.Length == 0 || nums1.Length == 0) return new int[] { };

        int idx1 = 0, idx2 = 0;
        var res = new List<int>();
        while (idx1 < nums1.Length && idx2 < nums2.Length) {
            int num1 = nums1[idx1], num2 = nums2[idx2];
            if (num1 == num2) {
                if (res.Count == 0 || res.Last() != num1) res.Add(num1);
                idx1++;
                idx2++;
            }
            else if (num1 < num2) {
                idx1++;
            }
            else {
                idx2++;
            }
        }

        return res.ToArray();
    }
}