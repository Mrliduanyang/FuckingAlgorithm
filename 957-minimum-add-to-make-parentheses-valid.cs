public class Solution {
    public int MinAddToMakeValid(string S) {
        int res = 0;
        int need = 0;
        foreach(var c in S){
            if (c == '('){
                need++;
            }
            if (c == ')'){
                need--;
                if (need == -1){
                    res++;
                    need = 0;
                }
            }
        }
        return res + need;
    }
}