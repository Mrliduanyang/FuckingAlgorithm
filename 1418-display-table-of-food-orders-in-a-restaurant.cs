using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<IList<string>> DisplayTable(List<List<string>> orders) {
        var foods = new HashSet<string>();
        var foodCount = new Dictionary<int, Dictionary<string, int>>();
        foreach (var order in orders) {
            var table = int.Parse(order[1]);
            var food = order[2];
            foods.Add(food);
            var dict = foodCount.ContainsKey(table) ? foodCount[table] : new Dictionary<string, int>();
            dict[food] = dict.GetValueOrDefault(food, 0) + 1;
            if (!foodCount.ContainsKey(table)) {
                foodCount[table] = dict;
            }
        }

        var res = new List<IList<string>>();
        var header = new List<string> {"Table"};
        var sortedFoods = foods.OrderBy(item => item).ToList();
        header.AddRange(sortedFoods);
        var tables = foodCount.Keys.OrderBy(item => item).ToList();
        res.Add(header);
        
        foreach (var table in tables) {
            var tableFoods = foodCount[table];
            var row = new List<string> {table.ToString()};
            foreach (var food in sortedFoods) {
                var val = tableFoods.ContainsKey(food) ? tableFoods[food] : 0;
                row.Add(val.ToString());
            }

            res.Add(row);
        }

        return res;
    }
}