public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        var dict = new Dictionary<char, int>();
        foreach(var ch in magazine){
            dict[ch] = dict.GetValueOrDefault(ch, 0) + 1;
        }
        foreach(var ch in ransomNote){
            if(!dict.ContainsKey(ch)){
                return false;
            }else{
                if(dict[ch] >= 1){
                    dict[ch]--;
                }else{
                    return false;
                }
            }
        }
        return true;
    }
} 