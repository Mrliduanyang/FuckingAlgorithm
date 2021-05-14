using System.Collections.Generic;

public class Solution {
    public List<List<int>> Permute(int[] nums) {
        var res = new List<List<int>>();
        var path = new List<int>();

        void Helper() {
            if (path.Count == nums.Length) {
                res.Add(path.ToList());
                return;
            }

            foreach (var num in nums) {
                if (path.Contains(num)) continue;
                path.Add(num);
                Helper();
                path.RemoveAt(path.Count - 1);
            }
        }

        Helper();
        return res;
    }
}