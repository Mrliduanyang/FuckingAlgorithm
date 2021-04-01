public class Solution {
    public int MaxProduct(int[] nums) {
        var max = (int[]) nums.Clone();
        var min = (int[]) nums.Clone();
        for (var i = 1; i < nums.Length; i++) {
            max[i] = Math.Max(Math.Max(max[i - 1] * nums[i], min[i - 1] * nums[i]), nums[i]);
            min[i] = Math.Min(Math.Min(min[i - 1] * nums[i], max[i - 1] * nums[i]), nums[i]);
        }

        return max.Max();
    }
}