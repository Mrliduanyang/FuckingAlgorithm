public class Solution {
    public string GetHint(string secret, string guess) {
        var dict = new int[10];
        int bulls = 0, cows = 0;
        for (var i = 0; i < secret.Length; i++) {
            var cs = secret[i] - '0';
            var cg = guess[i] - '0';
            if (cs == cg) {
                bulls++;
            }
            else {
                // 只有cs和cg不等时，才会变更个数。dict[cs] < 0说明在guess中有和cs不等的cg
                if (dict[cs] < 0) cows++;
                if (dict[cg] > 0) cows++;
                // cs总是增加，cg总是减少
                dict[cs]++;
                dict[cg]--;
            }
        }

        return $"{bulls}A{cows}B";
    }
}