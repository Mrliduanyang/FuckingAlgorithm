/**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class NestedIterator {
    private Stack<NestedInteger> stack = new Stack<NestedInteger>();

    public NestedIterator(IList<NestedInteger> nestedList)
    {
        for (int i = nestedList.Count - 1; i >= 0; i--)
        {
            stack.Push(nestedList[i]);
        }
    }

    public bool HasNext()
    {
        // 如果栈顶是List就不断展开压栈，直到找到第一个Integer为止
        while (stack.Count > 0 && !stack.Peek().IsInteger())
        {
            var p = stack.Pop();
            for (int i = p.GetList().Count - 1; i >= 0; i--)
            {
                stack.Push(p.GetList()[i]);
            }
        }
        return stack.Count > 0 && stack.Peek().IsInteger();
    }

    public int Next()
    {
        return stack.Pop().GetInteger();
    }
}


/**
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */