/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/

internal class Solution {
    public int GetImportance(IList<Employee> employees, int id) {
        Dictionary<int, Employee> dic = new Dictionary<int, Employee>();
        foreach (var item in employees) dic.Add(item.id, item);
        return GetRes(dic, id);
    }

    public int GetRes(Dictionary<int, Employee> dic, int id) {
        int res = dic[id].importance;
        foreach (var item in dic[id].subordinates) res += GetRes(dic, item);
        return res;
    }
}