public class Solution {
                    List<IList<int>> res = new List<IList<int>>();
                List<int> path =  new List<int>();
    public IList<IList<int>> FindSubsequences(int[] nums) {
 Helper(0, int.MinValue, nums);
                return res;
    }
    void Helper(int cur, int last, int[] nums) {
                    if (cur == nums.Length) {
                        if (path.Count >= 2) {
                            res.Add(path.ToList());
                        }
                        return;
                    }

                    if (nums[cur] >= last) {
                        path.Add(nums[cur]);
                        Helper(cur + 1, nums[cur], nums);
                        path.RemoveAt(path.Count - 1);
                    }
                    if (nums[cur] != last) {
                        Helper(cur + 1, last, nums);
                    }
                }
}