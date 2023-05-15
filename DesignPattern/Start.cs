using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class Start
    {
        static void Main(string[] args)
        {
            usingSorting();
        }

        static void meanMedianMode()
        {
            MeanMedianMode meanMedianMode = new MeanMedianMode(70);
            meanMedianMode.displaySampleWeights();
            Console.WriteLine("Mean :" + meanMedianMode.calculateMean());
            Console.WriteLine("10% Trimmed Mean :" + meanMedianMode.calculateTrimmedMean(10));
            Console.WriteLine("15% Trimmed Mean :" + meanMedianMode.calculateTrimmedMean(15));
            Console.WriteLine("Median :" + meanMedianMode.calculateMedian());
        }
        static void stackUsingLinkedList()
        {
            StackUsingLinkList stack = new StackUsingLinkList();
            Boolean exit = false;
            do
            {
                Console.WriteLine("For Stack Push:1 | Pop:2 | Peek:3 | IsEmpty:4 | Exit:0");
                Console.Write("Enter you input :");

                string? optionSelected = Console.ReadLine();
                int option = optionSelected != null ? Convert.ToInt32(optionSelected) : -1;


                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter your data:");
                        string? input = Console.ReadLine();
                        if (input != null)
                        {
                            stack.Push(input);
                        }
                        else
                        {
                            Console.WriteLine("Provide valid data.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Popped Data :" + stack.Pop());
                        break;
                    case 3:
                        Console.WriteLine("Peeked Data :" + stack.Peek());
                        break;
                    case 4:
                        Console.WriteLine("State :" + stack.IsEmpty());
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Select Valid Option.");
                        break;
                }
            } while (exit != true);
        }
        static void QueueUsingLinkedList()
        {
            QueueUsingLinkedList queue = new QueueUsingLinkedList();
            Boolean exit = false;
            int option, switchOption;
            do
            {
                Console.WriteLine("For Queue => EnQueue:1 | DeQueue:2 | Peek:3 | IsEmpty:4 | Exit:0");
                Console.Write("Enter you input :");
                string optionSelected = Console.ReadLine();

                if (int.TryParse(optionSelected, out option))
                    switchOption = option;
                else
                    switchOption = -1;

                switch (switchOption)
                {
                    case 1:
                        Console.WriteLine("EnQueue your data:");
                        string input = Console.ReadLine();
                        if (input != null)
                        {
                            queue.EnQueue(input);
                        }
                        else
                        {
                            Console.WriteLine("Provide valid data.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Dequeue Data :" + queue.DeQueue());
                        break;
                    case 3:
                        Console.WriteLine("Peeked Data :" + queue.Peek());
                        break;
                    case 4:
                        Console.WriteLine("State :" + queue.IsEmpty());
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Select Valid Option.");
                        break;
                }
            } while (exit != true);
        }
        static void circularLinkedList()
        {
            CircularLinkedList circularLinkedList = new CircularLinkedList();
            Boolean exit = false;
            int option, switchOption;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("For Circular Linked List => Insertion: 1 | Deletion: 2 | Peek All Node: 3 | IsEmpty: 4 | Exit: 0");
                Console.Write("Enter you input :");
                Console.ForegroundColor = ConsoleColor.White;
                string optionSelected = Console.ReadLine();

                if (int.TryParse(optionSelected, out option))
                    switchOption = option;
                else
                    switchOption = -1;

                switch (switchOption)
                {
                    case 1:
                        Console.WriteLine("Enter your data:");
                        string input = Console.ReadLine();
                        if (input != null)
                        {
                            circularLinkedList.Insertion(input);
                        }
                        else
                        {
                            Console.WriteLine("Provide valid data.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Key Data for Deletion:");
                        string keyData = Console.ReadLine();
                        Console.WriteLine("Enter key Position for Deletion:");
                        string enteredKeyPosition = Console.ReadLine();
                        int keyPosition;
                        if (!int.TryParse(enteredKeyPosition, out keyPosition))
                        {
                            Console.WriteLine("Please proide valid position.");
                            exit = true;
                        }
                        else
                        {
                            circularLinkedList.Deletion(keyData, keyPosition);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Peeked All Data :");
                        circularLinkedList.PeekAllNode();
                        break;
                    case 4:
                        Console.WriteLine("State :");
                        circularLinkedList.IsEmpty();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Select Valid Option.");
                        break;
                }
            } while (exit != true);
        }
        static void doubleLinkedList()
        {
            DoubleLinkedList doubleLinkedList = new DoubleLinkedList();
            Boolean exit = false;
            int option, switchOption;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("For Double Linked List => Insertion: 1 | Deletion: 2 | Peek All Node From Head: 3 | Peek All Node From Head: 4 |IsEmpty: 5 | Exit: 0");
                Console.Write("Enter you input :");
                Console.ForegroundColor = ConsoleColor.White;
                string optionSelected = Console.ReadLine();

                if (int.TryParse(optionSelected, out option))
                    switchOption = option;
                else
                    switchOption = -1;

                switch (switchOption)
                {
                    case 1:
                        Console.WriteLine("Enter your data:");
                        string input = Console.ReadLine();
                        if (input != null)
                        {
                            doubleLinkedList.Insertion(input);
                        }
                        else
                        {
                            Console.WriteLine("Provide valid data.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Key Data for Deletion:");
                        string keyData = Console.ReadLine();
                        Console.WriteLine("Enter key Position for Deletion:");
                        string enteredKeyPosition = Console.ReadLine();
                        int keyPosition;
                        if (!int.TryParse(enteredKeyPosition, out keyPosition))
                        {
                            Console.WriteLine("Please proide valid position.");
                            exit = true;
                        }
                        else
                        {
                            doubleLinkedList.Deletion(keyData, keyPosition);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Peeked All Data from Head :");
                        doubleLinkedList.PeekAllNodeFromHead();
                        break;
                    case 4:
                        Console.WriteLine("Peeked All Data from Tail :");
                        doubleLinkedList.PeekAllNodeFromTail();
                        break;
                    case 5:
                        Console.WriteLine("State :");
                        doubleLinkedList.IsEmpty();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Select Valid Option.");
                        break;
                }
            } while (exit != true);
        }

        static void usingHashSet()
        {
            //"MyHashSet","add","add","contains","contains","add","contains","remove","contains"
            //[[],[1],[2],[1],[3],[2],[2],[2],[2]]
            MyHashSet hashSet = new MyHashSet();

            hashSet.Add(9);
            hashSet.Remove(19);
            hashSet.Add(14);
            hashSet.Remove(19);
            hashSet.Remove(9);
            hashSet.Add(0);
            hashSet.Add(3);
            hashSet.Add(4);
            hashSet.Add(0);
            hashSet.Remove(9);
            //Console.WriteLine(hashSet.Contains(2));


        }

        static void usingSorting()
        {
            

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("                 Selection Sort");
            Console.ForegroundColor = ConsoleColor.White;
            int[] sel_num = new int[] { 7,98,3,6,99,32,5,28,1,49,12,56,62,39, 7, 98, 3, 6, 99, 32, 5, 28, 1, 49, 12, 56, 62, 39 };
            Sorting selectionSort = new Sorting(sel_num);
            selectionSort.PrintNumbers();
            selectionSort.SelectionSort();
            selectionSort.PrintNumbers();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("*****************************************************************");
            Console.WriteLine("                 Insertion Sort");
            Console.ForegroundColor = ConsoleColor.White;
            int[] ins_num = new int[] { 7, 98, 3, 6, 99, 32, 5, 28, 1, 49, 12, 56, 62, 39 };
            Sorting insertionSort = new Sorting(ins_num);
            insertionSort.PrintNumbers();
            insertionSort.InsertionSort();
            insertionSort.PrintNumbers();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("                 Bubble Sort");
            Console.ForegroundColor = ConsoleColor.White;
            int[] bub_num = new int[] { 7, 98, 3, 6, 99, 32, 5, 28, 1, 49, 12, 56, 62, 39 };
            Sorting bubbleSort = new Sorting(bub_num);
            bubbleSort.PrintNumbers();
            bubbleSort.BubbleSort();
            bubbleSort.PrintNumbers();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("                 Quick Sort");
            Console.ForegroundColor = ConsoleColor.White;
            int[] quick_num = new int[] { 7, 98, 3, 6, 99, 32, 5, 28, 1, 49, 12, 56, 62, 39 };
            Sorting quickSort = new Sorting(quick_num);
            quickSort.PrintNumbers();
            DateTime startTime = DateTime.Now;
            quickSort.QuickSort(0 , quick_num.Length-1);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Total Time Taken :" + (endTime - startTime).Milliseconds + " Milliseconds");
            quickSort.PrintNumbers();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****************************************************************");
            Console.WriteLine("                 Merge Sort");
            Console.ForegroundColor = ConsoleColor.White;
            int[] merge_num = new int[] { 19,21,9,5,8,17, 32, 5, 28, 1, 49, 12, 56, 62, 39 };
            Sorting mergeSort = new Sorting(merge_num);
            mergeSort.PrintNumbers();
            DateTime startTimeMerge = DateTime.Now;
            mergeSort.MergeSort(0, merge_num.Length - 1);
            DateTime endTimeMerge = DateTime.Now;
            Console.WriteLine("Total Time Taken :" + (endTimeMerge - startTimeMerge).Milliseconds + " Milliseconds");
            mergeSort.PrintNumbers();
        }
    }
}
