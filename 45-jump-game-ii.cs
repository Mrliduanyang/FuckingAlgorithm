public class Solution {
    public int Jump(int[] nums) {
                int length = nums.Length;
                int end = 0;
                int farthest = 0;
                int steps = 0;
                for (int i = 0; i < length - 1; i++) {
                    farthest = Math.Max(farthest, i + nums[i]);
                    if (i == end) {
                        end = farthest;
                        steps++;
                    }
                }
                return steps;
    }
}