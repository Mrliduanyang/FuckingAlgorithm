public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1) return s; //如果行数为一，直接返回字符串

        var res = new List<List<char>>();
        //为了防止字符串长度小于行数的特殊情况， 取行数和s的长度中最小的来初始化list.
        for (var i = 0; i < Math.Min(s.Length, numRows); i++) res.Add(new List<char>());

        var currRow = 0;
        var goDown = false;
        for (var i = 0; i < s.Length; i++) {
            res[currRow].Add(s[i]);
            if (currRow == 0 || currRow == numRows - 1) goDown = !goDown;
            currRow += goDown ? 1 : -1;
        }

        return string.Join("", res.Select(item => string.Join("", item)).ToList());
    }
}