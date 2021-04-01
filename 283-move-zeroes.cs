public class Solution {
    public void MoveZeroes(int[] nums) {
        int slow = -1, fast = 0;
        while (slow <= fast && fast <= nums.Length - 1)
            if (nums[fast] == 0) {
                fast++;
            }
            else {
                slow++;
                var tmp = nums[slow];
                nums[slow] = nums[fast];
                nums[fast] = tmp;
                fast++;
            }
    }
}