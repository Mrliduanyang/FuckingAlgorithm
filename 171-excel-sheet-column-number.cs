public class Solution {
    public int TitleToNumber(string columnTitle) {
        var ans = 0;
        for (var i = 0; i < columnTitle.Length; i++) {
            var num = columnTitle[i] - 'A' + 1;
            ans = ans * 26 + num;
        }

        return ans;
    }
}