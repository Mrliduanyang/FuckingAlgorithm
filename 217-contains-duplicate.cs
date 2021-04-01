public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var res = new SortedSet<int>();
        foreach (var num in nums)
            if (!res.Add(num))
                return true;
        return false;
    }
}