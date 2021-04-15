using System.Collections.Generic;

namespace FuckingAlgorithm {
    public class Program {
        public static int Test(string chnStr) {
            var unitMap = new Dictionary<char, int>() {
                {'一', 1}, {'十', 10}, {'百', 100}, {'千', 1000}, {'万', 10000}, {'亿', 100000000}
            };
            var numMap = new Dictionary<char, int>() {
                {'一', 1}, {'二', 2}, {'三', 3}, {'四', 4}, {'五', 5},
                {'六', 6}, {'七', 7}, {'八', 8}, {'九', 9}
            };
            int i = 0, j = 1;
            var totalNum = 0;
            var preUnit = 0;
            while (j < chnStr.Length) {
                var num = numMap[chnStr[i]];
                var numUnit = unitMap[chnStr[j]];

                if (numUnit > preUnit) {
                    totalNum += num;
                    totalNum *= numUnit;
                }
                else {
                    preUnit = numUnit;
                    var curNum = num * numUnit;
                    totalNum += curNum;
                }

                i += 2;
                j += 2;
            }

            return totalNum;
        }

        static void Main(string[] args) {
            var res = Test("一万零八十一亿零一万二千三百四十一一");
            System.Console.WriteLine(res);
        }
    }
}