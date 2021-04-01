public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
                var res = new List<int>();
                for (int i = 0; i < nums.Length; i++) {
                    int idx = Math.Abs(nums[i]) - 1;
                    // 如果 nums[tmp] < 0 则表示该数已出现过进行记录
                    if (nums[idx] > 0) {
                        nums[idx] = -nums[idx];
                    } else {
                        res.Add(idx + 1);
                    }
                }
                return res;
    }
}