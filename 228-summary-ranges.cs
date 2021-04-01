public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        var res = new List<string>();
        // i 初始指向第 1 个区间的起始位置
        var i = 0;
        for (var j = 0; j < nums.Length; j++) // j 向后遍历，直到不满足连续递增(即 nums[j] + 1 != nums[j + 1])
            // 或者 j 达到数组边界，则当前连续递增区间 [i, j] 遍历完毕，将其写入结果列表。
            if (j + 1 == nums.Length || nums[j] + 1 != nums[j + 1]) {
                // 将当前区间 [i, j] 写入结果列表
                var sb = new StringBuilder();
                sb.Append(nums[i]);
                if (i != j) sb.Append("->").Append(nums[j]);
                res.Add(sb.ToString());
                // 将 i 指向更新为 j + 1，作为下一个区间的起始位置
                i = j + 1;
            }

        return res;
    }
}