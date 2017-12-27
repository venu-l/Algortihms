namespace Microsoft.Venugopal.Algorithms.Arrays
{
    using System;

    using Microsoft.Venugopal.Algorithms.Common;

    public class SpiralOrder : IAlgoDriver
    {
        private int MatrixRowSize = 4;
        private int MatrixColumnSize = 4;
        private int[][] inputMatrix;

        Random randomNumberGenerator = new Random(934734);

        public SpiralOrder()
        {
            this.inputMatrix = new int[MatrixRowSize][];

            for (int i = 0; i < inputMatrix.Length; i++)
            {
                this.inputMatrix[i] = new int[this.MatrixColumnSize];

                for (int j = 0; j < this.MatrixColumnSize; j++)
                {
                    this.inputMatrix[i][j] = randomNumberGenerator.Next(0, 20);
                }
            }
        }

        public void Execute()
        {
            Console.WriteLine("Printing the Input Matrix:");
            Console.WriteLine("---------------------------");
            this.PrintMatrix(this.inputMatrix);


            Console.WriteLine();
            Console.WriteLine("Printing the Input Matrix in Spiral Order:");
            Console.WriteLine("---------------------------");

            // Logic to print in a Spiral Format. Change the Matrix or? Just Print? 
            int xTop, xBottom, yLeft, yRight;
            xTop = yLeft = 0;
            xBottom = this.MatrixRowSize - 1;
            yRight = this.MatrixColumnSize - 1;

            // Left to Right 
            // Increment Row Counter (High--)

            // Top to Bottom
            // Increment Column Counter (RightMost--)

            // Right to Left
            // Increment Row Counter (Low--)

            // Bottom to Top 
            // Increment Column Counter (LeftMost--)

            // Iterate Until the pointers either in X directions or Y directions cross each other!
            while (xTop < xBottom || yLeft < yRight)
            {
                for (int i = yLeft; i <= yRight; i++) Console.Write("{0}\t", this.inputMatrix[xTop][i]);
                xTop++;

                for (int i = xTop; i <= xBottom; i++) Console.Write("{0}\t", this.inputMatrix[i][yRight]);
                yRight--;

                for (int i = yRight; (i >= yLeft) && (yLeft < yRight); i--) Console.Write("{0}\t", this.inputMatrix[xBottom][i]);
                xBottom--;

                for (int i = xBottom; (i >= xTop) && (xTop < xBottom); i--) Console.Write("{0}\t", this.inputMatrix[i][yLeft]);
                yLeft++;
            }

        }

        private void PrintMatrix(int[][] matrixToPrint)
        {
            foreach (var eachArray in matrixToPrint)
            {
                foreach (var eachNumber in eachArray)
                {
                    Console.Write("{0}\t", eachNumber);
                }

                Console.WriteLine();
            }
        }
    }
}
