public class Solution {
    public int FindLengthOfLCIS(int[] nums) {
        var ans = 0;
        var n = nums.Length;
        var start = 0;
        for (var i = 0; i < n; i++) {
            if (i > 0 && nums[i] <= nums[i - 1]) start = i;
            ans = Math.Max(ans, i - start + 1);
        }

        return ans;
    }
}