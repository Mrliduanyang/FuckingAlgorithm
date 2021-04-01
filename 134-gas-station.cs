public class Solution {
            public int CanCompleteCircuit(int[] gas, int[] cost) {
                int n = gas.Length;
                int totalGas = 0;
                int curGas = 0;
                int startIdx = 0;
                for (int i = 0; i < n; i++) {
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