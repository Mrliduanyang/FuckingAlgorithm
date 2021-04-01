public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var n = nums.Length;
        if (n == 0) return 0;
        int slow = 0, fast = 1;
        var count = 1;
        while (fast < n) {
            if (nums[fast] == nums[fast - 1])
                count++;
            else
                count = 1;
            if (count <= 2) {
                slow++;
                nums[slow] = nums[fast];
            }

            fast++;
        }

        return slow + 1;
    }
}