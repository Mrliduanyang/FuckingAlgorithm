public class Solution {
    public List<int> GrayCode(int n) {
        var res = new List<int>();
        res.Add(0);
        var head = 1;
        for (var i = 0; i < n; i++) {
            for (var j = res.Count - 1; j >= 0; j--)
                res.Add(head + res[j]);
            head <<= 1;
        }

        return res;
    }
}