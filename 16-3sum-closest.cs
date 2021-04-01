public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        var ans = nums[0] + nums[1] + nums[2];
        for (var i = 0; i < nums.Length; i++) {
            int start = i + 1, end = nums.Length - 1;
            while (start < end) {
                var sum = nums[start] + nums[end] + nums[i];
                if (Math.Abs(target - sum) < Math.Abs(target - ans))
                    ans = sum;
                if (sum > target)
                    end--;
                else if (sum < target)
                    start++;
                else
                    return ans;
            }
        }

        return ans;
    }
}