public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        for (var i = 0; i < nums.Length; i++) {
            var newIdx = Math.Abs(nums[i]) - 1;
            if (nums[newIdx] > 0) nums[newIdx] *= -1;
        }

        var res = new List<int>();
        for (var i = 0; i < nums.Length; i++)
            if (nums[i] > 0)
                res.Add(i + 1);
        return res;
    }
}