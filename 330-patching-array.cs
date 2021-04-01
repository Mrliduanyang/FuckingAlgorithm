public class Solution {
    public int MinPatches(int[] nums, int n) {
        var patches = 0;
        long x = 1;
        int length = nums.Length, index = 0;
        while (x <= n)
            if (index < length && nums[index] <= x) {
                x += nums[index];
                index++;
            }
            else {
                x *= 2;
                patches++;
            }

        return patches;
    }
}