public class Solution {
    public int MaximumGap(int[] nums) {
                int n = nums.Length;
                if (n < 2) {
                    return 0;
                }
                long exp = 1;
                var buf = new int[n];
                var maxVal = nums.Max();
                // 基数排序，按照每一位数字大小在该位上将元素顺序排列，最后可得到从高位到低位的相对顺序排列
                while (maxVal >= exp) {
                    int[] cnt = new int[10];
                    for (int i = 0; i < n; i++) {
                        int digit = (nums[i] / (int) exp) % 10;
                        cnt[digit]++;
                    }
                    // 通过将基数索引累加，可以确定元素按基数顺序在数组中的位置
                    for (int i = 1; i < 10; i++) {
                        cnt[i] += cnt[i - 1];
                    }
                    for (int i = n - 1; i >= 0; i--) {
                        int digit = (nums[i] / (int) exp) % 10;
                        buf[cnt[digit] - 1] = nums[i];
                        cnt[digit]--;
                    }
                    buf.CopyTo(nums, 0);
                    exp *= 10;
                }
                int res = 0;
                for (int i = 1; i < n; i++) {
                    res = Math.Max(res, nums[i] - nums[i - 1]);
                }
                return res;
    }
}