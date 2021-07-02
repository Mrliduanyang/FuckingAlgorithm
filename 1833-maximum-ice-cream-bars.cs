using System;

public class Solution {
    public int MaxIceCream(int[] costs, int coins) {
        Array.Sort(costs);
        var res = 0;
        foreach (var cost in costs) {
            if (coins >= cost) {
                coins -= cost;
                ++res;
            }
            else {
                break;
            }
        }

        return res;
    }
}