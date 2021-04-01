public class Solution {
    public bool IsPowerOfFour(int n) {
        return (n > 0) && (Math.Log10(n) / Math.Log10(2) % 2 == 0);
    }
}