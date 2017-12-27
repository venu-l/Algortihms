namespace Microsoft.Venugopal.Algorithms.Arrays
{
    using System;

    using Microsoft.Venugopal.Algorithms.Common;

    /// <summary>
    /// Does rotate the matrix in place with out using a whole another matrix.
    /// </summary>
    public class RotateMatrixInplace : IAlgoDriver
    {
        private int MatrixSize = 5;
        private int[][] inputMatrix;
        private int layersToTarget;

        Random randomNumberGenerator = new Random(934734);

        public RotateMatrixInplace()
        {
            this.inputMatrix = new int[MatrixSize][];
            layersToTarget = MatrixSize / 2;

            for (int i = 0; i < inputMatrix.Length; i++)
            {
                this.inputMatrix[i] = new int[this.MatrixSize];
                
                for (int j = 0; j < this.MatrixSize; j++)
                {
                    this.inputMatrix[i][j] = randomNumberGenerator.Next(0, 20);
                }
            }
        }

        public void Execute()
        {
            throw new NotImplementedException();

            Console.WriteLine("Printing the Input Matrix:");
            Console.WriteLine("---------------------------");
            this.PrintMatrix(this.inputMatrix);

            Console.WriteLine();
            Console.WriteLine("Rotating the Input Matrix in 90 degrees:");
            this.ComputeRotatedMatrix();
            Console.WriteLine("---------------------------");

            Console.WriteLine("Printing the Rotated Matrix:");
            Console.WriteLine("---------------------------");
            this.PrintMatrix(this.rotatedMatrix);
        }

        private void ComputeRotatedMatrix()
        {
            /* 

            for (int currentLayer = 0; currentLayer < layersToTarget; currentLayer++)
            {
                for (int topToBottom = currentLayer; topToBottom < MatrixSize - currentLayer; topToBottom++)
                {
                    rotatedMatrix[MatrixSize - currentLayer - 1][topToBottom] = inputMatrix[topToBottom][currentLayer];
                }

                for (int leftToRight = currentLayer + 1; leftToRight < MatrixSize - currentLayer; leftToRight++)
                {
                    rotatedMatrix[MatrixSize - leftToRight - 1][MatrixSize - currentLayer - 1] = inputMatrix[MatrixSize - currentLayer - 1][leftToRight];
                }

                for (int bottomToTop = MatrixSize - currentLayer - 2; bottomToTop >= currentLayer; bottomToTop--)
                {
                    rotatedMatrix[currentLayer][bottomToTop] = inputMatrix[bottomToTop][MatrixSize - currentLayer - 1];
                }

                for (int rightToLeft = MatrixSize - currentLayer - 2; rightToLeft >= currentLayer; rightToLeft--)
                {
                    rotatedMatrix[MatrixSize - rightToLeft - 1][currentLayer] = inputMatrix[currentLayer][rightToLeft];
                }
            }

            // If matrix size is odd, middle element has to be tackled.
            if (MatrixSize % 2 != 0)
                rotatedMatrix[layersToTarget][layersToTarget] = inputMatrix[layersToTarget][layersToTarget];
            
             */
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
