public class Solution {
    public int FirstMissingPositive(int[] nums) {
        var n = nums.Length;
        for (var i = 0; i < n; i++)
            if (nums[i] <= 0)
                nums[i] = n + 1;
        for (var i = 0; i < n; i++) {
            var num = Math.Abs(nums[i]);
            if (num <= n) nums[num - 1] = -Math.Abs(nums[num - 1]);
        }

        for (var i = 0; i < n; ++i)
            if (nums[i] > 0)
                return i + 1;
        return n + 1;
    }
}