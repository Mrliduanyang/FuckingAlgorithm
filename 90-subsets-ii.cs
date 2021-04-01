public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        /**
            1。Array.Sort(nums);
            2。if (i > pos && nums[i] == nums[i - 1]) continue;
        */
        var res = new List<IList<int>>();
        if (nums == null || nums.Length <= 0) return res;

        Array.Sort(nums);

        Backtracking(nums, 0, new List<int>(), res);

        return res;
    }

    private void Backtracking(int[] nums, int pos, List<int> path, List<IList<int>> res) {
        res.Add(new List<int>(path));

        for (var i = pos; i < nums.Length; ++i) {
            if (i > pos && nums[i] == nums[i - 1]) continue;

            path.Add(nums[i]);
            Backtracking(nums, i + 1, path, res);
            path.RemoveAt(path.Count - 1);
        }
    }
}