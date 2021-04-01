public class Solution {
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        var res = new List<IList<int>>();
        Array.Sort(candidates);
        recrusion(candidates, 0, target, new List<int>(target), res);
        return res;
    }

    void recrusion(int[] candidates, int start, int target, IList<int> item, IList<IList<int>> res) {
        if(target == 0){
           res.Add(item.ToList());
        }
        if(target > 0){
          for(var i =start; i<candidates.Length;i++){
            if(candidates[i] <= target){
                item.Add(candidates[i]);
                recrusion(candidates,i, target -candidates[i], item, res);
                item.RemoveAt(item.Count()-1);
            }
            else{
              break;
            }
          }
        }
    }
}
