using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class CircularNode
    {
        public string data;
        public CircularNode next;

        public CircularNode(string data)
        {
            this.data = data;
        }
    }
    public class CircularLinkedList
    {
        public CircularNode head;
        private int length;


        public CircularLinkedList()
        {
            this.head = null;
            this.length = 0;
        }
        public void Insertion(string data)
        {
            CircularNode node = new CircularNode(data);
            if (this.head == null)
            {
                this.head = node;
                this.head.next = node;
                printConsoleMessage($"{data} - Inserted successfully.", true);
                this.length++;
            }
            else
            {
                CircularNode headNode = this.head;
                CircularNode rearNode = this.head;

                int nodeStart = 1;
                while (nodeStart < this.length)
                {
                    rearNode = rearNode.next;
                    nodeStart++;
                }
                rearNode.next = node;
                node.next = headNode;
                printConsoleMessage($"{data} - Inserted successfully.", true);                
                this.length++;
            }
        }
        public void PeekAllNode()
        {
            if (head == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Circuler Linked List is empty.");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                CircularNode headNode = head;
                int nodeStart = 0;
                while (nodeStart < this.length)
                {
                    Console.Write(headNode.data);
                    Console.Write("     |");
                    headNode = headNode.next;
                    nodeStart++;
                }

                Console.WriteLine("");
            }
        }

        private void printConsoleMessage(string message, bool successMessage)
        {
            Console.ForegroundColor = successMessage ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void IsEmpty()
        {
            if (head == null)
            {
                printConsoleMessage("Circuler Linked List is empty.", false);
            }
            else
            {
                printConsoleMessage("Circuler Linked List is not empty.", true);
            }
        }

        public void Deletion(string keyData, int keyPosition)
        {

            if (this.head == null)
            {
                printConsoleMessage("Circuler Linked List is empty.", false);
            }
            else
            {
                CircularNode headNode = this.head;
                int nodePosition = 1;
                if (keyPosition == 1)
                {
                    if (headNode.data != keyData)
                    {
                        printConsoleMessage($"{keyData} - not found at position - {keyPosition}.", false);
                    }
                    else
                    {
                        CircularNode secondLastRearNode = this.head;
                        while (nodePosition < this.length)
                        {
                            secondLastRearNode = secondLastRearNode.next;
                            nodePosition++;
                        }
                        if (secondLastRearNode == this.head)
                        {
                            this.head = null;
                            printConsoleMessage($"{keyData} - removed from position - {keyPosition}.", true);

                        }
                        else
                        {
                            this.head = headNode.next;
                            secondLastRearNode.next = headNode.next;
                            this.length--;
                            printConsoleMessage($"{keyData} - removed from position - {keyPosition}.", true);
                        }
                    }
                }
                else if (keyPosition == this.length)
                {
                    CircularNode rearNode = this.head;
                    while (nodePosition < this.length - 1)
                    {
                        rearNode = rearNode.next;
                        nodePosition++;
                    }
                    if (rearNode.next.data == keyData)
                    {
                        rearNode.next = headNode;
                        this.length--;
                        printConsoleMessage($"{keyData} - removed from position - {keyPosition}.", true);
                    }
                    else
                    {
                        printConsoleMessage($"{keyData} - not found at position - {keyPosition}.", true);
                    }
                }
                else if (keyPosition < this.length && keyPosition >= 1)
                {
                    CircularNode firstNode, secondNode = this.head;
                    bool keyFound = false;
                    while (nodePosition < this.length && nodePosition <= keyPosition)
                    {
                        firstNode = secondNode;
                        secondNode = secondNode.next;
                        nodePosition++;
                        if (secondNode.data == keyData)
                        {
                            keyFound = true;
                            firstNode.next = secondNode.next;
                            this.length--;
                            printConsoleMessage($"{keyData} - removed from position - {keyPosition}.", true);
                            break;
                        }
                    }
                    if (!keyFound)
                    {
                        printConsoleMessage($"{keyData} - not found at position - {keyPosition}.", true);
                    }                   
                }
                else
                {
                    printConsoleMessage($"Invalid position - {keyPosition}.", false);

                }
            }
        }
    }
}
