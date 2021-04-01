public class Solution {
    public bool CanCross(int[] stones) {
        var dict = new Dictionary<int, HashSet<int>>();
        for (var i = 0; i < stones.Length; ++i) dict[stones[i]] = new HashSet<int>();
        dict[0].Add(0);
        for (var i = 0; i < stones.Length; ++i)
            foreach (var step in dict[stones[i]])
                for (var newStep = step - 1; newStep <= step + 1; ++newStep)
                    if (newStep > 0 && dict.ContainsKey(stones[i] + newStep))
                        dict[stones[i] + newStep].Add(newStep);
        return dict[stones.Last()].Count > 0;
    }
}