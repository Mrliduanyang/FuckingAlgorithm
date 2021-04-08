using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        var map = new Dictionary<string, List<string>>();
        var itinerary = new List<string>();

        void Helper(string curr) {
            while (map.ContainsKey(curr) && map[curr].Count > 0) {
                var tmp = (string) map[curr].Min();
                map[curr].Remove(tmp);
                Helper(tmp);
            }

            itinerary.Add(curr);
        }


        foreach (var ticket in tickets) {
            string src = ticket[0], dst = ticket[1];
            if (!map.ContainsKey(src)) {
                map[src] = new List<string>();
            }

            map[src].Add(dst);
        }

        Helper("JFK");
        itinerary.Reverse();
        return itinerary.ToList();
    }
}