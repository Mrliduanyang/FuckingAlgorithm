public class Solution {


                public List<List<int>> TwoSumTarget(int[] nums, int start, int target) {
                var res = new List<List<int>>();
                int lo = start, hi = nums.Length - 1;
                while (lo < hi) {
                    int left = nums[lo], right = nums[hi];
                    int sum = nums[lo] + nums[hi];
                    if (sum < target) {
                        while (lo < hi && nums[lo] == left) lo++;
                    } else if (sum > target) {
                        while (lo < hi && nums[hi] == right) hi--;
                    } else if (sum == target) {
                        res.Add(new List<int> { left, right });
                        while (lo < hi && nums[lo] == left) lo++;
                        while (lo < hi && nums[hi] == right) hi--;
                    }
                }
                return res;
            }

            public IList<IList<int>> ThreeSum(int[] nums) {
                int target = 0;
                int start = 0;
                Array.Sort(nums);
                int n = nums.Length;
                var res = new List<IList<int>>();
                for (int i = start; i < n; i++) {
                    var tuples = TwoSumTarget(nums, i + 1, target - nums[i]);
                    foreach (var tuple in tuples) {
                        tuple.Add(nums[i]);
                        res.Add(tuple);
                    }
                    // 跳过第一个数字重复的情况。
                    while (i < n - 1 && nums[i] == nums[i + 1]) i++;
                }
                return res;
            }
}