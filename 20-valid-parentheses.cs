public class Solution {
    public bool IsValid(string s) {
        var left = new Stack<char>();
        foreach(var c in s){
            if(c == '(' || c == '[' || c == '{'){
                left.Push(c);
            }else{
                if(left.Count != 0 && LeftOf(c) == left.Peek()){
                    left.Pop();
                }else{
                    return false;
                }
            }
        }
        return left.Count == 0;
    }

                    public char LeftOf(char c) {
                    if (c == ')') return '(';
                    if (c == ']') return '[';
                    return '{';
                }
}