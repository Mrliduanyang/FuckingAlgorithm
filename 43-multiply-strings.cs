public class Solution {
    public string Multiply(string num1, string num2) {
                if (num1 == "0" || num2 == "0") return "0";
                int m = num1.Length, n = num2.Length;
                int[] res = new int[m + n];
                for (int i = m - 1; i >= 0; i--) {
                    for (int j = n - 1; j >= 0; j--) {
                        // 字符转为数字后相乘
                        int mul = (num1[i] - '0') * (num2[j] - '0');
                        // 乘积在结果中对应的位置
                        int p1 = i + j, p2 = i + j + 1;
                        // 处理本位和
                        int sum = mul + res[p2];
                        // 本位结果
                        res[p2] = sum % 10;
                        // 进位结果
                        res[p1] += sum / 10;
                    }
                }
                return string.Join("", res).TrimStart('0');
    }
}