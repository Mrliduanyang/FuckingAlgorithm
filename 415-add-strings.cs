public class Solution {
    public string AddStrings(string num1, string num2) {
                int carry = 0, i = num1.Length - 1, j = num2.Length - 1;
                var res = new StringBuilder();
                while (i >= 0 || j >= 0 || carry != 0) {
                    int x = i >= 0 ? num1[i] - '0' : 0;
                    int y = j >= 0 ? num2[j] - '0' : 0;
                    int tmp = x + y + carry;
                    res.Append(tmp % 10);
                    carry = tmp / 10;
                    i--;
                    j--;
                }
                return new string(res.ToString().Reverse().ToArray());
    }
}