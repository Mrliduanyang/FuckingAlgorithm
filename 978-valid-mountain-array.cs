public class Solution {
    public bool ValidMountainArray(int[] A) {
                // 双指针，从左右两边同时向中间靠近
                if (A.Length < 3) {
                    return false;
                }
                int left = 0, right = A.Length - 1;
                int i = 0;
                while (i < A.Length && left < right) {
                    if (A[left] < A[left + 1]) {
                        left++;
                    }
                    if (A[right] < A[right - 1]) {
                        right--;
                    }
                    i++;
                }
                return left == right && left != 0 && right != A.Length - 1;
    }
}