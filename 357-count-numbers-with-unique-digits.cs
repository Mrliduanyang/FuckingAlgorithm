public class Solution {
    public int CountNumbersWithUniqueDigits(int n) {
        if(n==0) return 1;
        n = Math.Min(n, 10);
        int ans = 10, bs = 9, sum = 9;
        for(int i = 1; i < n; i++){
            sum *= (bs--);
            ans += sum;
        }
        return ans;
    }
}