public class Solution {
    public void Rotate(int[] nums, int k) {
                k %= nums.Length;
                int[] left = new int[nums.Length - k];
                int[] right = new int[k];
                Array.Copy(nums, 0, left, 0, nums.Length - k);
                Array.Copy(nums, nums.Length - k, right, 0, k);
                // 将数组两部分分别翻转。
                Array.Reverse(left);
                Array.Reverse(right);
                left.CopyTo(nums, 0);
                right.CopyTo(nums, nums.Length - k);
                // 合并后把整个数组翻转。
                Array.Reverse(nums);
    }
}