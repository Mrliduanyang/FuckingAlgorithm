public class Solution {
    public List<IList<int>> PermuteUnique(int[] nums) {
        List<IList<int>> res = new List<IList<int>>();
        List<int> path = new List<int>();
        var vis = new bool[nums.Length];
        Array.Sort(nums);
        backtrack(nums, res, 0, path, vis);
        return res;
    }

    public void backtrack(int[] nums, List<IList<int>> res, int idx, List<int> path, bool[] vis) {
        if (idx == nums.Length) {
            res.Add(path.ToList());
            return;
        }

        for (var i = 0; i < nums.Length; ++i) {
            if (vis[i] || i > 0 && nums[i] == nums[i - 1] && !vis[i - 1]) continue;
            path.Add(nums[i]);
            vis[i] = true;
            backtrack(nums, res, idx + 1, path, vis);
            vis[i] = false;
            path.RemoveAt(idx);
        }
    }
}