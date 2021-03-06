public class Solution {
    public bool CheckPossibility(int[] nums) {
        var n = nums.Length;
        if (n <= 1) return true;
        var down = 0;
        for (var i = 1; i < n; i++)
            if (nums[i] < nums[i - 1]) {
                down++;
                if (down > 1) return false;
                if (i > 1 && i < n - 1 && nums[i - 1] > nums[i + 1] && nums[i - 2] > nums[i]) return false;
            }

        return true;
    }
}