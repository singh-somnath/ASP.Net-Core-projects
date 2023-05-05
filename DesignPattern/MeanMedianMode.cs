using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    public class MeanMedianMode
    {
        private int[] sampleWeights;

        public MeanMedianMode(int length)
        {
            Random random = new Random();
            sampleWeights = new int[length];
            for(int i=0;i<length; i++)
            {
                sampleWeights[i] = random.Next(100,2000);
            }

            this.getSortedWeightts();
        }

        private void getSortedWeightts()
        {
            for(int i=0; i< this.sampleWeights.Length-1; i++)
            {
                for(int j=0; j< this.sampleWeights.Length -i-1; j++)
                {
                    int _flag;
                    if (this.sampleWeights[j] > this.sampleWeights[j+1])
                    {
                        _flag = this.sampleWeights[j];
                        this.sampleWeights[j] = this.sampleWeights[j+1];
                        this.sampleWeights[j+1] = _flag;
                    }
                }
            }
        }

        public void displaySampleWeights()
        {
            int counter = 0;
            int initialIndex = 0;
            int totalCounter = this.sampleWeights.Length / 20 + (this.sampleWeights.Length % 20 ==0 ? 0 : 1);
            do
            {               
                for (int i=0; i< 20; i++ )
                {
                    if (initialIndex < this.sampleWeights.Length)
                    {
                        int curentIndex = initialIndex++;
                        Console.Write(this.sampleWeights[curentIndex]);
                        Console.Write(" | ");
                    }
                    else
                    {
                        break;
                    }
                }
                Console.Write("\n");
                counter = counter + 1;

            } while (counter <= totalCounter);
        }

        public double calculateMean() 
        {
            int sum = 0;
            for(int i=0; i< this.sampleWeights.Length; i++)
            {
                sum = sum + this.sampleWeights[i];
            }

            return  sum/this.sampleWeights.Length;
        }

        public double calculateTrimmedMean(int trimmedPercentage)
        {
            int trimmedIndexes = this.sampleWeights.Length/trimmedPercentage;
            int sum = 0;
            for(int i = trimmedIndexes-1; i <= this.sampleWeights.Length-trimmedIndexes; i++) 
            {
                sum = sum + this.sampleWeights[i];
            }
            return sum / this.sampleWeights.Length;
        }

        public double calculateMedian()
        {
            int medianIndex = this.sampleWeights.Length / 2;
            if (medianIndex % 2 == 0)
                return ((this.sampleWeights[medianIndex - 1] + this.sampleWeights[medianIndex]) / 2);
            else
                return this.sampleWeights[medianIndex];
           
        }
    }
}
