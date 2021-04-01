public class Solution {
    public int EvalRPN(string[] tokens) {
        var stack = new Stack<int>();
        foreach (var token in tokens) {
            var num = 0;
            if (int.TryParse(token, out num)) {
                stack.Push(num);
            }
            else {
                var num1 = stack.Pop();
                var num2 = stack.Pop();
                switch (token) {
                    case "+":
                        stack.Push(num2 + num1);
                        break;
                    case "-":
                        stack.Push(num2 - num1);
                        break;
                    case "*":
                        stack.Push(num2 * num1);
                        break;
                    case "/":
                        stack.Push(num2 / num1);
                        break;
                    default:
                        continue;
                }
            }
        }

        return stack.Pop();
    }
}