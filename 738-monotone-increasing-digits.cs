public class Solution {
    public int MonotoneIncreasingDigits(int N) {
                var digits = N.ToString().ToCharArray();
                int i = 1;
                while (i < digits.Length && digits[i - 1] <= digits[i]) {
                    i++;
                }
                if (i < digits.Length) {
                    while (i > 0 && digits[i - 1] > digits[i]) {
                        digits[i - 1]--;
                        i--;
                    }
                    for(++i; i < digits.Length; i++){
                        digits[i] = '9';
                    }
                }
                return int.Parse(new string(digits));
    }
}