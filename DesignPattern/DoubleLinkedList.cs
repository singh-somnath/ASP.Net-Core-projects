using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPattern
{
    public class DoubleNode
    {
        public DoubleNode prev;
        public string data;
        public DoubleNode next;

        public DoubleNode(string data) 
        {
            this.prev = null;
            this.data = data;
            this.next = null;
        }
    }
    public class DoubleLinkedList
    {
        public DoubleNode head;
        public DoubleNode tail;
        public int length;

        public DoubleLinkedList()
        {
            this.head = null;
            this.length = 0;
            this.tail = null;
        }
        private void printConsoleMessage(string message, bool successMessage)
        {
            Console.ForegroundColor = successMessage ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void IsEmpty()
        {
            if(this.head == null)
            {
                printConsoleMessage("Double Linked List is empty.", false);
            }
            else
            {
                {
                    printConsoleMessage("Double Linked List is not empty.", true);
                }
            }
        }

        public void Insertion(string data)
        {
            DoubleNode node = new DoubleNode(data);

            if(this.head == null)
            {
                this.head = node;
                this.tail = node;
                printConsoleMessage($"{data} Inserted Successfully.", true);
            }
            else
            {
                DoubleNode currentRearNode = this.head;
                while(currentRearNode.next != null)
                {
                    currentRearNode = currentRearNode.next;
                }
                node.prev = currentRearNode;
                currentRearNode.next = node;
                this.tail = currentRearNode.next;
                printConsoleMessage($"{data} Inserted Successfully.", true);
            }
            this.length++;
        }

        public void PeekAllNodeFromHead()
        {

            if (this.head == null)
            {
                printConsoleMessage(" Double Linked list is empty.", false);

            }
            else
            {
                DoubleNode currentNode = this.head;
                do
                {
                    Console.Write($"{currentNode.data}   |");
                    currentNode = currentNode.next;
                } while (currentNode != null);
                Console.WriteLine("");
            }
        }
        public void PeekAllNodeFromTail()
        {

            if (this.head == null)
            {
                printConsoleMessage(" Double Linked list is empty.", false);

            }
            else
            {
                DoubleNode currentNode = this.tail;
                do
                {
                    Console.Write($"{currentNode.data}   |");
                    currentNode = currentNode.prev;
                } while (currentNode != null);
                Console.WriteLine("");
            }
        }
        public void Deletion(string keyData, int keyPosition)
        {
            DoubleNode headNode = this.head;
            if(headNode == null)
            {
                printConsoleMessage("Double Linked List is empty.", false);
            }
            else
            {
                if(keyPosition == 1)
                {
                    if (headNode.data == keyData)
                    {
                        if (this.length == 1)
                        {
                            this.head = null;
                            this.tail = null;
                        }
                        else
                        {
                            this.head = this.head.next;
                            this.head.prev = null;
                        }
                        this.length--;
                        printConsoleMessage($"{keyData} deleted from {keyPosition}", true);
                    }
                    else
                    {
                        printConsoleMessage($"{keyData} is not in position - {keyPosition}", false);
                    }
                }
                else if(keyPosition == this.length)
                {
                    DoubleNode lastNode = this.tail;
                    if(lastNode.data == keyData)
                    {
                        this.tail = lastNode.prev;
                        this.tail.next = null;
                        this.length--;
                        printConsoleMessage($"{keyData} deleted from {keyPosition}", true);
                    }
                    else
                    {
                        printConsoleMessage($"{keyData} is not in position - {keyPosition}", false);
                    }
                }
                else if(keyPosition > 1 && keyPosition < this.length )
                {
                    DoubleNode currentNode = this.head;
                    int nodePosition = 1;
                    bool keyFound = false;
                    while (nodePosition < this.length)
                    {
                        if (currentNode.data == keyData)
                        {
                            keyFound = true;
                            var previousNode = currentNode.prev;
                            var nextNode = currentNode.next;
                            previousNode.next = nextNode;
                            nextNode.prev = previousNode;
                            this.length--;
                            printConsoleMessage($"${keyData} removed from {keyPosition}.", true);
                            break;
                        }
                        currentNode = currentNode.next;
                    }
                    if(!keyFound)
                    {
                        printConsoleMessage($"${keyData} not found in {keyPosition}.", false);
                    }
                }
                else
                {
                    printConsoleMessage($"Invalid Key Position {keyPosition}.", false);
                }
            }

        }
    }
}
