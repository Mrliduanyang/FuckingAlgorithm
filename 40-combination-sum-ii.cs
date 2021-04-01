public class Solution {
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
                                var path = new List<int>();
                var res = new List<IList<int>>();
                var vis = new bool[candidates.Length];

                void Helper(int curr, int sum) {
                    if (sum == target) {
                        res.Add(path.ToList());
                        return;
                    } else if (sum < target) {
                        for (int i = curr; i < candidates.Length; i++) {
                            if ((i > 0 && candidates[i] == candidates[i - 1] && !vis[i - 1])) {
                                continue;
                            }
                            path.Add(candidates[i]);
                            vis[i] = true;
                            Helper(i + 1, sum + candidates[i]);
                            vis[i] = false;
                            path.RemoveAt(path.Count - 1);
                        }
                    }
                }

                Array.Sort(candidates);
                Helper(0, 0);
                return res;
    }
}