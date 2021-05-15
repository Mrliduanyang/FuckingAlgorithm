public class Solution {
    public int Multiply(int A, int B) {
        int Helper(int num, int times) {
            if (times == 0) return 0;
            return num + Helper(num, times - 1);
        }

        return A > B ? Helper(A, B) : Helper(B, A);
    }
}