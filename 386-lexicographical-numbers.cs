public class Solution {
    public IList<int> LexicalOrder(int n) {
        var res = new List<int>();

        void Helper(int i) {
            if (i > n) return;
            res.Add(i);
            for (var j = 0; j < 10; j++) Helper(i * 10 + j);
        }

        for (var i = 1; i < 10; i++) Helper(i);
        return res;
    }
}