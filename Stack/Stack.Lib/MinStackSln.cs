﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

//push(x) -- Push element x onto stack.
//pop() -- Removes the element on top of the stack.
//top() -- Get the top element.
//getMin() -- Retrieve the minimum element in the stack.
//Example:
//MinStack minStack = new MinStack();
//minStack.push(-2);
//minStack.push(0);
//minStack.push(-3);
//minStack.getMin();   --> Returns -3.
//minStack.pop();
//minStack.top();      --> Returns 0.
//minStack.getMin();   --> Returns -2.
namespace Stack.Lib
{
    public class MinStackSln
    {
        private Queue<int> _q1 = new Queue<int>();
        private Queue<int> _q2 = new Queue<int>();

        /** Initialize your data structure here. */
        public MinStackSln()
        {

        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            if (_q1.Count == 0)
                _q1.Enqueue(x);
            else
            {
                int front = _q1.Dequeue();
                _q2.Enqueue(front);
                _q1.Enqueue(x);
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            int q2cnt = _q2.Count;
            if (q2cnt > 0)
            {
                while (q2cnt-- > 1)
                {
                    int tmp = _q2.Dequeue();
                    _q2.Enqueue(tmp);
                }
                _q1.Enqueue(_q2.Dequeue());
            }
            return _q1.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            return _q1.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return _q1.Count == 0 && _q2.Count == 0;
        }
    }
}
