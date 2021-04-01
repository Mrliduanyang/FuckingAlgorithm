public class Solution {
    public IList<int> AddToArrayForm(int[] A, int K) {
        var temp = K;
        var i = A.Length - 1;

        List<int> ans = new List<int>();

        while (i >= 0 || temp > 0) {
            if (i >= 0) temp += A[i];
            ans.Add(temp % 10);
            temp /= 10;
            i--;
        }

        ans.Reverse();
        return ans;
    }
}