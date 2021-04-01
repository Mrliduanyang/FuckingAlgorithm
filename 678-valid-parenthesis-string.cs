public class Solution {
    public bool CheckValidString(string s) {
                var leftStack = new Stack<int>();
                var starStack = new Stack<int>();
                for (int i = 0; i < s.Length; i++) {
                    if (s[i] == '(') {
                        leftStack.Push(i);
                    } else if (s[i] == '*') {
                        starStack.Push(i);
                    } else {
                        if (leftStack.Count != 0) {
                            leftStack.Pop();
                        } else if (starStack.Count != 0) {
                            starStack.Pop();
                        } else {
                            return false;
                        }
                    }
                }
                if (leftStack.Count > starStack.Count) return false;
                while (leftStack.Count != 0 & starStack.Count != 0) {
                    if (leftStack.Peek() > starStack.Peek())
                        return false;
                    else {
                        leftStack.Pop();
                        starStack.Pop();
                    }
                }
                if (leftStack.Count == 0) return true;
                return false;
    }
}