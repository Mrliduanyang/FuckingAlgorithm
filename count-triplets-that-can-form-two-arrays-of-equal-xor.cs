public class Solution {
    public int CountTriplets(int[] arr) {
        var n = arr.Length;
        var s = new int[n + 1];
        for (var i = 0; i < n; ++i) {
            s[i + 1] = s[i] ^ arr[i];
        }
        var ans = 0;
        for (var i = 0; i < n; ++i) {
            for (var j = i + 1; j < n; ++j) {
                for (var k = j; k < n; ++k) {
                    if (s[i] == s[k + 1]) {
                        ++ans;
                    }
                }
            }
        }
        return ans;
    }
}