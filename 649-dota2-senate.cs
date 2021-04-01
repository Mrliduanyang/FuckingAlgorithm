public class Solution {
    public string PredictPartyVictory(string senate) {
        var n = senate.Length;
        Queue<int> radiant = new Queue<int>();
        Queue<int> dire = new Queue<int>();
        for (var i = 0; i < n; ++i)
            if (senate[i] == 'R')
                radiant.Enqueue(i);
            else
                dire.Enqueue(i);
        while (radiant.Count != 0 && dire.Count != 0) {
            int radiantIndex = radiant.Dequeue(), direIndex = dire.Dequeue();
            if (radiantIndex < direIndex)
                radiant.Enqueue(radiantIndex + n);
            else
                dire.Enqueue(direIndex + n);
        }

        return radiant.Count != 0 ? "Radiant" : "Dire";
    }
}