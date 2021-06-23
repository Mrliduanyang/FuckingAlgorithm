public class Solution {
    public int HammingWeight(uint n) {
        var res = 0;
        while (n != 0) {
            n &= (n - 1);
            ++res;
        }

        return res;
    }
}