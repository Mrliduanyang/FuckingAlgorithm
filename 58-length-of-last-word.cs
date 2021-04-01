public class Solution {
    public int LengthOfLastWord(string s) {
        int lenght = 0;
            int i = s.Length - 1;
            while (i >= 0 && (s[i] != ' '||i==s.Length-1||(i<s.Length-1&&s[i+1]==' ')))
            {
                if (s[i] != ' ')
                {
                    ++lenght;
                    --i;
                }
                else { --i; }
            }
            return lenght;
    }
}