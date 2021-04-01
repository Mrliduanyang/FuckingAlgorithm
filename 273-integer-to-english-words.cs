public class Solution {
    public string NumberToWords(int num) {
                var less20 = new[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tens = new[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                var units = new[] { "", "Thousand", "Million", "Billion" };

                string Helper(int num) {
                    if (num == 0) return "";
                    else if (num < 20) {
                        return less20[num] + " ";
                    } else if (num < 100) {
                        return tens[num / 10] + " " + Helper(num % 10);
                    } else {
                        return Helper(num / 100) + "Hundred " + Helper(num % 100);
                    }
                }

                if (num == 0) return "Zero";
                int i = 0;
                string words = "";

                while (num > 0) {
                    if (num % 1000 != 0) {
                        words = Helper(num % 1000) + units[i] + " " + words;
                    }
                    num /= 1000;
                    i++;
                }
                return words.Trim();
    }
}