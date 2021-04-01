public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var result = new List<IList<int>>();
        if (nums == null || nums.Length <= 0) return result;

        Array.Sort(nums);
        
        BackTracking(nums, 0, new List<int>(), result);

        return result;
    }

    private void BackTracking(int[] nums, int pos, List<int> path, List<IList<int>> result){
        result.Add(new List<int>(path));

        for (int i = pos; i < nums.Length; ++i){
            path.Add(nums[i]);
            BackTracking(nums, i + 1, path, result);
            path.RemoveAt(path.Count - 1);
        }
    }
}
