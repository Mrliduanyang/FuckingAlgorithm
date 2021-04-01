public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        var n = gas.Length;
        var totalGas = 0;
        var curGas = 0;
        var startIdx = 0;
        for (var i = 0; i < n; i++) {
            totalGas += gas[i] - cost[i];
            curGas += gas[i] - cost[i];
            if (curGas < 0) {
                startIdx = i + 1;
                curGas = 0;
            }
        }

        return totalGas >= 0 ? startIdx : -1;
    }
}