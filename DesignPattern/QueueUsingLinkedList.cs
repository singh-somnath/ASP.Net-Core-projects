using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class QueueNode
    {
        public string data;
        public QueueNode next;
        public QueueNode(string data) 
        {
            this.data = data;
            this.next = null;
        }
    }
    public class QueueUsingLinkedList
    {
        public QueueNode front;
        public QueueNode rear;

        public void EnQueue(string data)
        {
            QueueNode node = new QueueNode(data);
            if(this.front == null) 
            {
                this.front = node;
                this.rear = node;
            }
            else
            {
                QueueNode tempNode = this.rear;
                this.rear = node;
                this.rear.next = tempNode;
            }
        }

        public string DeQueue()
        {
            if(this.front == null)
            {
                return "Queue is Empty";
            }
            else if(this.front == this.rear)
            {
                QueueNode currentNode = this.front;
                this.front = null;
                this.rear = null;
                return currentNode.data;
            }
            else
            {
                QueueNode frontNode = this.front;
                QueueNode rearNode = this.rear;
                QueueNode currentPreviousFrontNode = null;

                while (rearNode != null)
                {
                    currentPreviousFrontNode = rearNode;
                    if (rearNode.next == frontNode)
                       break;
                    rearNode = rearNode.next;
                }

                this.front = currentPreviousFrontNode;
                this.front.next = null;
                return frontNode.data;
            }
        }

        public string Peek()
        {
            if(this.front != null)
            {
                return this.front.data;
            }
            else
            {
                return "Queue is empty.";
            }
        }

        public string IsEmpty()
        {
            if(this.front == null)
            {
                return "Queue is empty";
            }
            else
            {
                return "Queue is not empty";
            }
        }
    }
}
