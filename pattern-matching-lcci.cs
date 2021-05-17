using System.Text;

public class Solution {
    public bool PatternMatching(string pattern, string value) {
        int countA = 0, countB = 0;
        var startWithA = pattern.StartsWith('a');

        foreach (var ch in pattern) {
            if (ch == 'a') {
                ++countA;
            }
            else {
                ++countB;
            }
        }

        var n = value.Length;

        for (var lenA = 0; lenA < n; ++lenA) {
            var patA = value[..lenA];
            for (var lenB = 0; lenB < n; ++lenB) {
                if (countA * lenA + countB * lenB == n) {
                    var patB = "";
                    var bIdx = 1;
                    while (bIdx < pattern.Length) {
                        if (pattern[bIdx] == (startWithA ? 'b' : 'a')) {
                            patB = value.Substring((lenA * bIdx), lenB);
                            break;
                        }
                    }

                    var newValue = new StringBuilder();
                    foreach (var ch in pattern) {
                        if (ch == 'a') {
                            newValue.Append(patA);
                        }
                        else {
                            newValue.Append(patB);
                        }
                    }

                    if (newValue.ToString() == value) {
                        return true;
                    }
                }
            }
        }


        return false;
    }
}