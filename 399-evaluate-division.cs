public class Solution {
 public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
            Dictionary<string,int> dNode = new Dictionary<string, int>();
            Dictionary<int,Dictionary<int,double>> map = new Dictionary<int, Dictionary<int, double>>();
            int index = 0;
            for (int i = 0; i < values.Length; i++)
            {
                string a = equations[i][0];
                string b = equations[i][1];
                if (dNode.ContainsKey(a)==false)
                {
                    dNode.Add(a,index);
                    map.Add(index,new Dictionary<int, double>());
                    index++;
                }
                if (dNode.ContainsKey(b)==false)
                {
                    dNode.Add(b,index);
                    map.Add(index,new Dictionary<int, double>());
                    index++;
                }
                if (map[dNode[a]].ContainsKey(dNode[b])==false)
                {
                    map[dNode[a]].Add(dNode[b],values[i]);
                }
                if (map[dNode[b]].ContainsKey(dNode[a])==false)
                {
                    map[dNode[b]].Add(dNode[a],1/values[i]);
                }
            }
            double[] result = new double[queries.Count];
            for (int i = 0; i < result.Length; i++)
            {
                if (dNode.ContainsKey(queries[i][0])==false || dNode.ContainsKey(queries[i][1])==false)
                {
                    result[i] = -1.0;                        
                }else{
                    bool[] visited = new bool[index];
                    result[i]= SearchResult(map,visited,dNode[queries[i][0]],dNode[queries[i][1]],1.0);
                }
                
            }
            return result;
        }

        private double SearchResult(Dictionary<int, Dictionary<int, double>> map, bool[] visited,int start,int target,double cur)
        {
            if (start==target)
            {
                return cur;
            }
            visited[start] = true;
            var dNext = map[start];
            if (dNext.ContainsKey(target))
            {
                return SearchResult(map,visited,target,target,cur*dNext[target]);
            }
            foreach (var item in dNext)
            {
                if (visited[item.Key]==false)
                {
                    var result = SearchResult(map,visited,item.Key,target,cur*item.Value);
                    if (result>=0)
                    {
                        return result;
                    }
                }
            }
            return -1.0;
        }

}
