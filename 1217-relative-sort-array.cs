public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        int upper = arr1.Max();
        var frequency = new int[upper + 1];
        foreach (var x in arr1) frequency[x]++;
        var ans = new int[arr1.Length];
        var index = 0;
        foreach (var x in arr2) {
            for (var i = 0; i < frequency[x]; ++i) ans[index++] = x;
            frequency[x] = 0;
        }

        for (var x = 0; x <= upper; ++x)
        for (var i = 0; i < frequency[x]; ++i)
            ans[index++] = x;
        return ans;
    }
}