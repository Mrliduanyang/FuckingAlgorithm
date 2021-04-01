public class Solution {
    public int[] SortArrayByParityII(int[] A) {
        var n = A.Length;
        if (n == 0) return new int[] { };
        var odd = new List<int>();
        var even = new List<int>();
        var res = new List<int>();
        foreach (var num in A)
            if (num % 2 == 0)
                even.Add(num);
            else
                odd.Add(num);
        for (var i = 0; i < n / 2; i++) {
            res.Add(even[i]);
            res.Add(odd[i]);
        }

        return res.ToArray();
    }
}