public class Solution {
    public int[] Decode(int[] encoded, int first) {
        var n = encoded.Length + 1;
        var arr = new int[n];
        arr[0] = first;
        for (var i = 1; i < n; i++) {
            arr[i] = arr[i - 1] ^ encoded[i - 1];
        }
        return arr;
    }
}