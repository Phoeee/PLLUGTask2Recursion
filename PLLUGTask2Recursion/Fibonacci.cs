using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLLUGTask2Recursion
{
    class Fibonacci
    {
        private static readonly Dictionary<ulong, ulong> MemorizedSequence = new Dictionary<ulong, ulong>();
      
        // Recursion method
        internal ulong GetFibonacciSequencebyAmountMy(ulong number)
        {
            if (number == 0 || number == 1)
            {
                return number;
            }
            return MemorizeFibonacci(number - 1) + MemorizeFibonacci(number - 2);
           
        }

        // Method to memorize Fibonacci calculations
        private ulong MemorizeFibonacci(ulong number)
        {
            if (MemorizedSequence.ContainsKey(number))
            {
                return MemorizedSequence[number];
            }
            ulong result = GetFibonacciSequencebyAmountMy(number);
            MemorizedSequence.Add(number, result);
            return result;
        }
     
        public ulong GetFibonacciSequencebyAmountSuggested(ulong a, ulong b, ulong counter, ulong number)
        {

            if (counter < number)
            {
                return GetFibonacciSequencebyAmountSuggested(b, a + b, counter + 1, number);
            }
            return b;
    
        }

        public List<ulong> GetFibonacciSequenceByNumber(ulong number)
        {
            uint counter = 0;
            List<ulong> sequence = new List<ulong>();
            while (GetFibonacciSequencebyAmountMy(counter) <= number)
            {
                counter++;
                sequence.Add(GetFibonacciSequencebyAmountMy(counter));

            }
            sequence.Remove(GetFibonacciSequencebyAmountMy(counter));
            return sequence;
        }

    }
}
