public class Solution {
    public int FindMaxLength(int[] nums) {
                var dict = new Dictionary<int, int>();
                dict[0] = -1;
                int maxlen = 0, count = 0;
                for (int i = 0; i < nums.Length; i++) {
                    count = count + (nums[i] == 1 ? 1 : -1);
                    if (dict.ContainsKey(count)) {
                        maxlen = Math.Max(maxlen, i - dict[count]);
                    } else {
                        dict[count] = i;
                    }
                }
                return maxlen;
    }
}