public class Solution {
    public string SimplifyPath(string path) {
        var stack = new Stack<string>();
                var paths = path.Split("/");
                foreach (var item in paths) {
                    if (item == "") {
                        continue;
                    }
                    if (item == "..") {
                        if (stack.Count > 0) {
                            stack.Pop();
                        }
                    } else if (item != ".") {
                        stack.Push(item);
                    }
                }
                if (stack.Count > 0) {
                    var res = new List<string>();
                    while (stack.Count != 0) {
                        res.Insert(0, stack.Pop());
                        res.Insert(0, "/");
                    }
                    return string.Join("", res);
                } else {
                    return "/";
                }
    }
}