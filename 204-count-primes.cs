public class Solution {
    public int CountPrimes(int n) {
        var isPrime = new int[n];
        Array.Fill(isPrime, 1);
        var ans = 0;
        for (var i = 2; i < n; ++i)
            if (isPrime[i] == 1) {
                ans += 1;
                if ((long) i * i < n)
                    for (var j = i * i; j < n; j += i)
                        isPrime[j] = 0;
            }

        return ans;
    }
}