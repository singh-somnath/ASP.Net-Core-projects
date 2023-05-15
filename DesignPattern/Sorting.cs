using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class Sorting
    {
        private int[] num;

        public Sorting(int[] num)
        {
            this.num = num;
        }

        public void BubbleSort()
        {
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < this.num.Length - 1; i++)
            {
                for (int j = 0; j < this.num.Length - i - 1; j++)
                {
                    if (this.num[j] < this.num[j + 1])
                    {
                        int temp = this.num[j];
                        this.num[j] = this.num[j + 1];
                        this.num[j + 1] = temp;
                    }
                }
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Total Time Taken :" + (endTime - startTime).Milliseconds + " Milliseconds");

        }

        public void SelectionSort()
        {
            DateTime startTime = DateTime.Now;

            for (int i = 0; i < this.num.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < this.num.Length; j++)
                {
                    if (this.num[j] > this.num[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = this.num[i];
                this.num[i] = this.num[minIndex];
                this.num[minIndex] = temp;

            }

            DateTime endTime = DateTime.Now;
            Console.WriteLine("Total Time Taken :" + (endTime - startTime).Milliseconds + " Milliseconds");
        }

        public void InsertionSort()
        {
            DateTime startTime = DateTime.Now;

            for (int i = 1; i < this.num.Length; i++)
            {
                int key = this.num[i];
                int j = i - 1;

                while (j >= 0 && key > this.num[j])
                {
                    this.num[j + 1] = this.num[j];
                    j--;
                }
                this.num[j + 1] = key;
            }

            DateTime endTime = DateTime.Now;
            Console.WriteLine("Total Time Taken :" + (endTime - startTime).Milliseconds + " Milliseconds");
        }
       
        //Quick Sort Start //
        public void QuickSort(int low, int high)
        {           
            if (low < high)
            {
                int pivotIndex = PivotElement(low, high);
                QuickSort(low, pivotIndex);
                QuickSort(pivotIndex + 1, high);

            }            
        }

        private int PivotElement(int low, int high)
        {
            int pivot = this.num[low];
            int i = low;
            int j = high;

            while (i < j)
            {
                while (this.num[++i] <= pivot)
                {
                    if (i >= high) break;
                }
                while (this.num[j] >= pivot)
                {
                    if (j <= low) break;
                    j--;
                }

                if (i < j)
                    swap(this.num, i, j);

            }
            swap(this.num, low, j);
            return j;
        }

        private void swap(int[] arr, int firstIndex, int secondIndex)
        {
            int temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }
        //Quick Sort End //

        //Merge Sort Start//
        public void MergeSort(int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSort(low, mid);
                MergeSort(mid + 1, high);
                Merge(low, mid, high);
            }
           
        }
        private void Merge(int low, int mid, int high)
        {
            int leftArray_i = low;
            int leftArray_j = mid;
            int rightArray_i = mid+1;
            int rightArray_j = high;
            
            int[] dummyArray = new int[high + 1];
            int index = -1;
           
            while (leftArray_i <= leftArray_j && rightArray_i<= rightArray_j)
            {
                if (this.num[leftArray_i] > this.num[rightArray_i])
                {
                    dummyArray[++index] = this.num[rightArray_i++];                    
                }
                else
                {
                    dummyArray[++index] = this.num[leftArray_i++];
                   
                }
               
            }

            while (leftArray_i <= leftArray_j)
            {
                dummyArray[++index] = this.num[leftArray_i++];              
                
            }

            while (rightArray_i <= rightArray_j)
            {
                dummyArray[++index] = this.num[rightArray_i++];               

            }

            index = 0;
            int i = low;
            int j = high;
            while( i <= j)
            {
                this.num[i++] = dummyArray[index++];            
            }
         

        }
        //Merge Sort End //

        public void PrintNumbers()
        {
            Console.WriteLine("Numbers :");
            for (int i = 0; i < this.num.Length; i++)
            {
                Console.Write($"\t{this.num[i]}");
            }
            Console.WriteLine();
        }

    }
}
