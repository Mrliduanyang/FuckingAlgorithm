public class Solution {
                    List<IList<int>> res = new List<IList<int>>();
List<int> track = new List<int>();
    public IList<IList<int>> Permute(int[] nums) {
                // 回溯路径
                
                backtrack(nums);
                return res;
    }

                    void backtrack(int[] nums) {
                    if (track.Count == nums.Length) {
                        // 结束条件，如果nums中所有元素都在track中，找到一个全排列，添加进全排列结果里
                        res.Add(track.ToList());
                        return;
                    }
                    // 做选择
                    foreach (var num in nums) {
                        // 如果路径中已存在元素num，则跳过
                        if (track.Contains(num)) {
                            continue;
                        }
                        // 做选择
                        track.Add(num);
                        // 进入下一层选择
                        backtrack(nums);
                        // 回溯，撤销选择
                        track.RemoveAt(track.Count - 1);
                    }
                }
}