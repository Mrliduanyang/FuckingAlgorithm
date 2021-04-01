public class Solution {
    public bool DetectCapitalUse(string word) {
        if (word.ToUpper() == word) return true;
        if (word.Substring(1).ToLower() == word.Substring(1)) return true;
        return false;
    }
}