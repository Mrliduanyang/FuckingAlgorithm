public class Solution {
    public string ConvertToTitle(int n) {
                var s = new StringBuilder();
                while (n != 0) {
                    n--;
                    s.Insert(0,(char) ('A' + n % 26));
                    n = n / 26;
                }
                return s.ToString();
    }
}