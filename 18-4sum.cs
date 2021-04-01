public class Solution {
    public List<List<int>> TwoSumTarget(int[] nums, int start, int target) {
        var res = new List<List<int>>();
        int lo = start, hi = nums.Length - 1;
        while (lo < hi) {
            int left = nums[lo], right = nums[hi];
            var sum = nums[lo] + nums[hi];
            if (sum < target) {
                while (lo < hi && nums[lo] == left) lo++;
            }
            else if (sum > target) {
                while (lo < hi && nums[hi] == right) hi--;
            }
            else if (sum == target) {
                res.Add(new List<int> {left, right});
                while (lo < hi && nums[lo] == left) lo++;
                while (lo < hi && nums[hi] == right) hi--;
            }
        }

        return res;
    }

    public List<List<int>> ThreeSumTarget(int[] nums, int start, int target) {
        Array.Sort(nums);
        var n = nums.Length;
        var res = new List<List<int>>();
        for (var i = start; i < n; i++) {
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

    public IList<IList<int>> FourSum(int[] nums, int target) {
        Array.Sort(nums);
        var n = nums.Length;
        var res = new List<IList<int>>();
        for (var i = 0; i < n; i++) {
            // 对 target - nums[i] 计算 ThreeSum
            var triples = ThreeSumTarget(nums, i + 1, target - nums[i]);
            // 如果存在满足条件的三元组，再加上 nums[i] 就是结果四元组
            foreach (var triple in triples) {
                triple.Add(nums[i]);
                res.Add(triple);
            }

            while (i < n - 1 && nums[i] == nums[i + 1]) i++;
        }

        return res;
    }
}