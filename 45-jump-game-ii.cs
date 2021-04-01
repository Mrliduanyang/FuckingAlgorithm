public class Solution {
    public int Jump(int[] nums) {
        var length = nums.Length;
        var end = 0;
        var farthest = 0;
        var steps = 0;
        for (var i = 0; i < length - 1; i++) {
            farthest = Math.Max(farthest, i + nums[i]);
            if (i == end) {
                end = farthest;
                steps++;
            }
        }

        return steps;
    }
}