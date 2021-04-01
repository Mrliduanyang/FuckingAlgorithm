public class Solution {
    public int ArrayPairSum(int[] nums) {
        Array.Sort(nums);
        var max = 0;
        for (var i = 0; i < nums.Length; i += 2) max += nums[i];
        return max;
    }
}