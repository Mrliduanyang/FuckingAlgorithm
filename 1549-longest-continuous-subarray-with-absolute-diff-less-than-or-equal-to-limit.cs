public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
                int left = 0, right = 0, n = nums.Length;
                var max = new LinkedList<int>();
                var min = new LinkedList<int>();
                while (right < n) {
                    right++;
                    while (max.Count > 0 && nums[max.Last()] <= nums[right - 1]) max.RemoveLast();
                    while (min.Count > 0 && nums[min.Last()] >= nums[right - 1]) min.RemoveLast();
                    max.AddLast(right - 1);
                    min.AddLast(right - 1);
                    if (max.First() < left) max.RemoveFirst();
                    if (min.First() < left) min.RemoveFirst();
                    if (nums[max.First()] - nums[min.First()] > limit) left++;
                }
                return right - left;
    }
}