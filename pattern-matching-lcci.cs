using System;
using System.Text;

public class Solution {
    public bool PatternMatching(string pattern, string value) {
        int countA = 0, countB = 0;
        if (!pattern.StartsWith('a')) {
            pattern = pattern.Replace('a', 'c');
            pattern = pattern.Replace('b', 'a');
            pattern = pattern.Replace('c', 'b');
        }

        foreach (var ch in pattern) {
            if (ch == 'a') {
                ++countA;
            }
            else {
                ++countB;
            }
        }

        if (value.Length == 0) {
            return countB == 0;
        }

        var n = value.Length;

        for (var lenA = 0; lenA <= n; ++lenA) {
            var patA = value[..lenA];
            for (var lenB = 0; lenB <= n; ++lenB) {
                if (countA * lenA + countB * lenB == n) {
                    var patB = "";
                    var bIdx = 1;
                    while (bIdx < pattern.Length) {
                        if (pattern[bIdx] == 'b') {
                            patB = value.Substring((lenA * bIdx), lenB);
                            break;
                        }

                        ++bIdx;
                    }

                    Console.WriteLine($"{patA},{patB}");

                    var newValue = new StringBuilder();
                    foreach (var ch in pattern) {
                        newValue.Append(ch == 'a' ? patA : patB);
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