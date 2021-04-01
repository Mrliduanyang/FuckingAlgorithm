public class Solution {
    public string IntToRoman(int num) {
                var values = new [] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
                var symbols = new [] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
                var res = new StringBuilder();
                for (int i = 0; i < values.Length && num >= 0; i++) {
                    while (values[i] <= num) {
                        num -= values[i];
                        res.Append(symbols[i]);
                    }
                }
                return res.ToString();
    }
}