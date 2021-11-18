package main

type TreeNode struct {
	Val   int
	Left  *TreeNode
	Right *TreeNode
}

func findTilt(root *TreeNode) int {
	res := 0
	var helper func(*TreeNode) int
	helper = func(node *TreeNode) int {
		if node == nil {
			return 0
		}
		left := helper(node.Left)
		right := helper(node.Right)
		res += abs(left - right)
		return left + right + node.Val
	}
	helper(root)
	return res
}

func abs(x int) int {
	if x < 0 {
		return -x
	}
	return x
}
