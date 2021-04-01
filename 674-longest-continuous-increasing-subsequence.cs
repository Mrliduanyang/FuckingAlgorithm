public class Solution {
    public int FindLengthOfLCIS(int[] nums) {
int ans = 0;
        int n = nums.Length;
        int start = 0;
        for (int i = 0; i < n; i++) {
            if (i > 0 && nums[i] <= nums[i - 1]) {
                start = i;
            }
            ans = Math.Max(ans, i - start + 1);
        }
        return ans;

    }
}