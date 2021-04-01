public class Solution {
    public int ReachNumber(int target) {
        target = Math.Abs(target);
        var k = 0;
        while (target > 0)
            target -= ++k;
        return target % 2 == 0 ? k : k + 1 + k % 2;
    }
}