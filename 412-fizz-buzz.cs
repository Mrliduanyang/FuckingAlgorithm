public class Solution {
    public IList<string> FizzBuzz(int n) {
        var ans = new List<string>();
        for (var num = 1; num <= n; num++) {
            var divisibleBy3 = num % 3 == 0;
            var divisibleBy5 = num % 5 == 0;

            var numAnsStr = "";
            if (divisibleBy3) numAnsStr += "Fizz";
            if (divisibleBy5) numAnsStr += "Buzz";
            if (numAnsStr == "") numAnsStr += num;
            ans.Add(numAnsStr);
        }

        return ans;
    }
}