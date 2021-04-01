public class Solution {
    public int[] CountBits(int num) {
        var res = new int[num + 1];
        res[0] = 0;
        for (var i = 0; i <= num; i++)
            if (i % 2 == 1)
                res[i] = res[i - 1] + 1;
            else
                res[i] = res[i / 2];
        return res;
    }
}