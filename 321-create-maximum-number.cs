public class Solution {
    public int[] MaxNumber(int[] nums1, int[] nums2, int k) {
                int[] Pick_max(int[] nums, int k) {
                    int len = nums.Length;
                    int[] stack = new int[k];
                    int top = -1;
                    int remain = len - k;
                    for (int i = 0; i < len; i++) {
                        int num = nums[i];
                        while (top >= 0 && stack[top] < num && remain > 0) {
                            top--;
                            remain--;
                        }
                        if (top < k - 1) {
                            stack[++top] = num;
                        } else {
                            remain--;
                        }
                    }
                    return stack;
                }

                int[] Merge(int[] sub1, int[] sub2) {
                    int a = sub1.Length, b = sub2.Length;
                    if (a == 0) {
                        return sub2;
                    }
                    if (b == 0) {
                        return sub1;
                    }
                    int merglen = a + b;
                    int[] m = new int[merglen];
                    int n1 = 0, n2 = 0;
                    for (int i = 0; i < merglen; i++) {
                        if (Compare(sub1, sub2, n1, n2) > 0) {
                            m[i] = sub1[n1++];
                        } else {
                            m[i] = sub2[n2++];
                        }
                    }
                    return m;
                }

                int Compare(int[] sub1, int[] sub2, int n1, int n2) {
                    int a = sub1.Length, b = sub2.Length;
                    while (n1 < a && n2 < b) {
                        int dif = sub1[n1] - sub2[n2];
                        if (dif != 0) {
                            return dif;
                        }
                        n1++;
                        n2++;
                    }
                    return (a - n1) - (b - n2);
                }

                int[] res = new int[k];
                int n1 = nums1.Length;
                int n2 = nums2.Length;
                int start = Math.Max(0, k - n2), end = Math.Min(k, n1);
                for (int i = start; i <= end; i++) {
                    int[] sub1 = Pick_max(nums1, i);
                    int[] sub2 = Pick_max(nums2, k - i);
                    int[] cur = Merge(sub1, sub2);
                    if (Compare(cur, res, 0, 0) > 0) {
                        Array.Copy(cur, 0, res, 0, k);
                    }
                }
                return res;
    }
}