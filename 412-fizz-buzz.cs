public class Solution {
    public IList<string> FizzBuzz(int n) {
                var ans = new List<string>();
                for (int num = 1; num <= n; num++) {
                    bool divisibleBy3 = (num % 3 == 0);
                    bool divisibleBy5 = (num % 5 == 0);

                    var numAnsStr = "";
                    if (divisibleBy3) {
                        numAnsStr += "Fizz";
                    }
                    if (divisibleBy5) {
                        numAnsStr += "Buzz";
                    }
                    if (numAnsStr == "") {
                        numAnsStr += num;
                    }
                    ans.Add(numAnsStr);
                }
                return ans;
    }
}