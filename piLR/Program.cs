using System;
using System.Diagnostics;

namespace piLR
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Let's bake some Pi with Leibnitz! Type in your desired # of iterations for the approximation:");
            string input = Console.ReadLine();
            try
            {
                // Retrieve the input
                int tmpEndNum = int.Parse(input);

                // Set up he calculator
                LReiheCalc calc = new LReiheCalc(tmpEndNum);
                decimal piApprox = calc.PerformCalculation();

                // Print out the result
                Console.WriteLine("Pi for a accuracy of {0} is: {1}", tmpEndNum, piApprox.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Please provide a valid input argument instead of {0}", input);
                Console.WriteLine("Error message: {0}, Error Stacktrace: {1}", e.Message, e.StackTrace);
                return 1;
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            return 0;
        }
    }

    //
    class LReiheCalc
    {

        private const int startNum = 0;
        private int endNum;
        private decimal pieApprox = 0m;

        private Stopwatch sWatch = new Stopwatch();

        public LReiheCalc(int endNumber)
        {
            this.endNum = endNumber;
        }

        public decimal PerformCalculation()
        {
            sWatch.Start();
            int incK = 0;
            int multiplier = 1;

            while (incK < this.endNum)
            {
                // Upper part
                multiplier = multiplier * -1;

                // Lower part
                decimal tmpBottom = 2 * incK + 1;

                // Save the result
                decimal tmpResult = multiplier * 1 / tmpBottom;

                // Accumulate pi
                pieApprox += tmpResult;

                // Next iteration
                incK++;
            }
            pieApprox = (pieApprox * 4) * -1;

            sWatch.Stop();
            Console.WriteLine("Calculation took {0}ms to perform.", sWatch.ElapsedMilliseconds);

            return pieApprox;
        }

    }
}
