public class Solution {
    public int[] XorQueries(int[] arr, int[][] queries) {
        var n = arr.Length;
        var xors = new int[n + 1];
        for (var i = 0; i < n; i++) {
            xors[i + 1] = xors[i] ^ arr[i];
        }

        var m = queries.Length;
        var ans = new int[m];
        for (var i = 0; i < m; i++) {
            ans[i] = xors[queries[i][0]] ^ xors[queries[i][1] + 1];
        }

        return ans;
    }
}