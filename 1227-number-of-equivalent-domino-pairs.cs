public class Solution {
    public int NumEquivDominoPairs(int[][] dominoes) {
        var num = new int[100];
        var ret = 0;
        foreach (var domino in dominoes) {
            var val = domino[0] < domino[1] ? domino[0] * 10 + domino[1] : domino[1] * 10 + domino[0];
            ret += num[val];
            num[val]++;
        }

        return ret;
    }
}