public class Solution {
    public int LongestConsecutive(int[] nums) {
                var set = new HashSet<int>(nums);
                int res = 0;
                foreach (var num in set) {
                    if (!set.Contains(num - 1)) {
                        int curNum = num;
                        int curLen = 1;
                        while (set.Contains(curNum + 1)) {
                            curNum += 1;
                            curLen += 1;
                        }
                        res = Math.Max(res, curLen);
                    }
                }
                return res;
    }
}