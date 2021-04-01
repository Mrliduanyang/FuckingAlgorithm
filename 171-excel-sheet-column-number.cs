public class Solution {
            public int TitleToNumber(string columnTitle) {
                int ans = 0;
                for (int i = 0; i < columnTitle.Length; i++) {
                    int num = columnTitle[i] - 'A' + 1;
                    ans = ans * 26 + num;
                }
                return ans;
            }
}