public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
        var dict = new Dictionary<int, int>();
        foreach (var numA in A)
        foreach (var numB in B)
            dict[numA + numB] = dict.GetValueOrDefault(numA + numB, 0) + 1;
        var ans = 0;
        foreach (var numC in C)
        foreach (var numD in D)
            if (dict.ContainsKey(-(numC + numD)))
                ans += dict[-(numC + numD)];
        return ans;
    }
}