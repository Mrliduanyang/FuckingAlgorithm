using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int Clumsy(int N) {
        var stack = new Stack<int>();
        stack.Push(N);
        --N;
        var index = 0; // 用于控制乘、除、加、减
        while (N > 0) {
            if (index % 4 == 0)
                stack.Push(stack.Pop() * N);
            else if (index % 4 == 1)
                stack.Push(stack.Pop() / N);
            else if (index % 4 == 2)
                stack.Push(N);
            else
                stack.Push(-N);

            ++index;
            --N;
        }

        return stack.Sum();
    }
}