package main

type Node struct {
	Val   int
	Prev  *Node
	Next  *Node
	Child *Node
}

func flatten(root *Node) *Node {
	if root == nil {
		return root
	}

	stack := []*Node{root}
	dummy := &Node{0, nil, root, nil}
	prev := dummy
	for len(stack) != 0 {
		cur := stack[len(stack)-1]
		stack = stack[:len(stack)-1]
		prev.Next = cur
		cur.Prev = prev
		if cur.Next != nil {
			stack = append(stack, cur.Next)
		}
		if cur.Child != nil {
			stack = append(stack, cur.Child)
			cur.Child = nil
		}

		prev = cur
	}

	dummy.Next.Prev = nil
	return dummy.Next
}
