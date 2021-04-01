public class Solution {
    public IList<int> GetRow(int rowIndex) {
        if (rowIndex < 0) return new List<int>();
        if (rowIndex == 0) return new List<int> {1};
        var res = new List<int> {1, 1};
        for (var i = 0; i <= rowIndex; i++) {
            var row = new List<int>();
            row.Add(1);
            for (var j = 1; j < i; j++) row.Add(res[j - 1] + res[j]);
            row.Add(1);
            res = row;
        }

        return res;
    }
}