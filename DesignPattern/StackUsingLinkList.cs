using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class Node
    {
        public string data;
        public Node next;

        public Node(string data)
        {
            this.data = data;
            this.next = null;
        }
    }
    public class StackUsingLinkList
    {
        private Node top;

        public StackUsingLinkList()
        {
            this.top = null;
        }

        public void Push(string data)
        {
            Node newNode = new Node(data);
            if(this.top != null)
            {
                newNode.next = this.top;
                this.top = newNode;
            }
            else
            {
                this.top = newNode;
            }
        }

        public string Pop()
        {
            string data;
            if(this.top != null)
            {
                data = this.top.data;
                this.top = this.top.next;
            }
            else
            {
                return "Stack is Empty";
            }
            return data;
        }

        public string Peek()
        {
            string peekData;
            if(this.top != null)
            {
                peekData = this.top.data;
            }
            else
            {
                return "Stack is Empty";
            }
            return peekData;
        }

        public string IsEmpty()
        { 
           if(this.top == null)
            {
                return "Stack is Empty";
            }
            else
            {
                return "Stack is not empty.";
            }

        }
    }
}
