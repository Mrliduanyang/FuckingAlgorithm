public class Solution {
    public int MinMoves(int[] nums) {
        int moves = 0, min = int.MaxValue;
        for (var i = 0; i < nums.Length; i++) {
            moves += nums[i];
            min = Math.Min(min, nums[i]);
        }

        return moves - min * nums.Length;
    }
}