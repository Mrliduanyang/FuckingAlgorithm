public class Solution {
    public int FindNthDigit(int n) {
        if (n == 0) return 0;
        var digit = 1; // digit位数
        long start = 1; // digit位数的起始数
        var idxCount = digit * 9 * start; // digit位数范围内索引长度

        while (n > idxCount) {
            n = (int) (n - idxCount);
            ++digit;
            start *= 10;
            idxCount = digit * 9 * start;
        }

        var num = start + (n - 1) / digit;
        var remainder = (n - 1) % digit;
        return num.ToString()[remainder] - '0';
    }
}