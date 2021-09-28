package main

//   Definition for a binary tree node.
type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func pathSum(root *TreeNode, targetSum int) int {
	preSum := map[int]int{0: 1}
	var helper func(*TreeNode, int) int
	helper = func(node *TreeNode, sum int) int {
		if node == nil {
			return 0
		}
		ret := 0
		sum += node.Val
		ret += preSum[sum-targetSum]
		preSum[sum]++
		ret += helper(node.Left, sum)
		ret += helper(node.Right, sum)
		preSum[sum]--
		return ret
	}
	return helper(root, 0)
}
