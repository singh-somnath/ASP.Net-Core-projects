using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class Start
    {
        static void Main(string[] args)
        {
            QueueUsingLinkedList();

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
                        if(input != null)
                        {
                            stack.Push(input);
                        }
                        else
                        {
                            Console.WriteLine("Provide valid data.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Popped Data :"+ stack.Pop());
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
    }
}
