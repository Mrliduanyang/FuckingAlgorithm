public class Solution {
    public int MaximumSwap(int num) {
                var nums = num.ToString().ToArray();
                int[] idx = new int[nums.Length];
                int maxIdx = nums.Length - 1;
                for (int i = nums.Length - 1; i >= 0; i--) {
                    if (nums[i] > nums[maxIdx]) maxIdx = i;
                    idx[i] = maxIdx;
                }
                for (int i = 0; i < nums.Length; i++) {
                    if (nums[i] != nums[idx[i]]) {
                        var temp = nums[i];
                        nums[i] = nums[idx[i]];
                        nums[idx[i]] = temp;
                        break;
                    }
                }
                return int.Parse(nums);
    }
}