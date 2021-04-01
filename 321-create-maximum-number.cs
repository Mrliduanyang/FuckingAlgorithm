public class Solution {
    public int[] MaxNumber(int[] nums1, int[] nums2, int k) {
        int[] Pick_max(int[] nums, int k) {
            var len = nums.Length;
            var stack = new int[k];
            var top = -1;
            var remain = len - k;
            for (var i = 0; i < len; i++) {
                var num = nums[i];
                while (top >= 0 && stack[top] < num && remain > 0) {
                    top--;
                    remain--;
                }

                if (top < k - 1)
                    stack[++top] = num;
                else
                    remain--;
            }

            return stack;
        }

        int[] Merge(int[] sub1, int[] sub2) {
            int a = sub1.Length, b = sub2.Length;
            if (a == 0) return sub2;
            if (b == 0) return sub1;
            var merglen = a + b;
            var m = new int[merglen];
            int n1 = 0, n2 = 0;
            for (var i = 0; i < merglen; i++)
                if (Compare(sub1, sub2, n1, n2) > 0)
                    m[i] = sub1[n1++];
                else
                    m[i] = sub2[n2++];
            return m;
        }

        int Compare(int[] sub1, int[] sub2, int n1, int n2) {
            int a = sub1.Length, b = sub2.Length;
            while (n1 < a && n2 < b) {
                var dif = sub1[n1] - sub2[n2];
                if (dif != 0) return dif;
                n1++;
                n2++;
            }

            return a - n1 - (b - n2);
        }

        var res = new int[k];
        var n1 = nums1.Length;
        var n2 = nums2.Length;
        int start = Math.Max(0, k - n2), end = Math.Min(k, n1);
        for (var i = start; i <= end; i++) {
            var sub1 = Pick_max(nums1, i);
            var sub2 = Pick_max(nums2, k - i);
            var cur = Merge(sub1, sub2);
            if (Compare(cur, res, 0, 0) > 0) Array.Copy(cur, 0, res, 0, k);
        }

        return res;
    }
}