public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var path = new List<int>();
        var res = new List<IList<int>>();
        var nums = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

        void Helper(int curr, int sum, int len) {
            if (sum == n && len == k) {
                res.Add(path.ToList());
                return;
            }

            for (var i = curr; i < nums.Length; i++) {
                path.Add(nums[i]);
                Helper(i + 1, sum + nums[i], len + 1);
                path.RemoveAt(path.Count - 1);
            }
        }

        Helper(0, 0, 0);
        return res;
    }
}