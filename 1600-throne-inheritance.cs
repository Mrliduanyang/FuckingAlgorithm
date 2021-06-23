using System.Collections.Generic;

public class ThroneInheritance {
    private Dictionary<string, List<string>> edges;
    private HashSet<string> dead;
    private string king;

    public ThroneInheritance(string kingName) {
        edges = new Dictionary<string, List<string>>();
        dead = new HashSet<string>();
        king = kingName;
    }

    public void Birth(string parentName, string childName) {
        List<string> children;
        if (edges.TryGetValue(parentName, out children)) {
            children.Add(childName);
            edges[parentName] = children;
        }
        else {
            children = new List<string> {childName};
            edges[parentName] = children;
        }
    }

    public void Death(string name) {
        dead.Add(name);
    }

    public IList<string> GetInheritanceOrder() {
        var ans = new List<string>();
        Preorder(ans, king);
        return ans;
    }

    private void Preorder(IList<string> ans, string name) {
        if (!dead.Contains(name)) {
            ans.Add(name);
        }

        var children = edges.ContainsKey(name) ? edges[name] : new List<string>();
        foreach (var childName in children) {
            Preorder(ans, childName);
        }
    }
}

/**
 * Your ThroneInheritance object will be instantiated and called as such:
 * ThroneInheritance obj = new ThroneInheritance(kingName);
 * obj.Birth(parentName,childName);
 * obj.Death(name);
 * IList<string> param_3 = obj.GetInheritanceOrder();
 */