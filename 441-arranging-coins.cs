public class Solution {
    public int ArrangeCoins(int n) {
        return (int)(Math.Sqrt(2) * Math.Sqrt(n + 0.125) - 0.5);
    }
}