/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/

class Solution {
    public int GetImportance(IList<Employee> employees, int id) {
        var dict = employees.ToDictionary(employee => employee.id, employee => employee);
        var res = 0;
        void Helper(int id){
            var employee = dict[id];
            res += employee.importance;
            foreach(var subordinate in employee.subordinates){
                Helper(subordinate);
            }
        }
        Helper(id);
        return res;
    }
}
