public class Solution {
    public string RemoveKdigits(string num, int k) {
        var deque = new List<char>();
        foreach (var item in num) {
            while (deque.Count != 0 && k > 0 && deque.Last() > item) {
                deque.RemoveAt(deque.Count - 1);
                k--;
            }

            deque.Add(item);
        }

        for (var i = 0; i < k; i++) deque.RemoveAt(deque.Count - 1);
        var res = new string(deque.ToArray()).TrimStart('0');
        return res.Length == 0 ? "0" : res;
    }
}