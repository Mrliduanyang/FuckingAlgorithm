public class Solution {
    public bool IsPossible(int[] nums) {
        var numCount = new SortedDictionary<int, int>();
        var tail = new SortedDictionary<int, int>();
        foreach (var num in nums) numCount[num] = numCount.GetValueOrDefault(num, 0) + 1;
        foreach (var num in nums)
            if (numCount[num] == 0) {
            }
            else if (numCount[num] > 0 && tail.GetValueOrDefault(num - 1, 0) > 0) {
                numCount[num]--;
                tail[num - 1]--;
                tail[num] = tail.GetValueOrDefault(num, 0) + 1;
            }
            else if (numCount.GetValueOrDefault(num + 1, 0) > 0 && numCount.GetValueOrDefault(num + 2, 0) > 0) {
                numCount[num]--;
                numCount[num + 1]--;
                numCount[num + 2]--;
                tail[num + 2] = tail.GetValueOrDefault(num + 2, 0) + 1;
            }
            else {
                return false;
            }

        return true;
    }
}