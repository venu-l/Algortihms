namespace Microsoft.Venugopal.Algorithms
{
    using System.Collections;
    using System.Diagnostics;
    using Microsoft.Venugopal.Algorithms.LinkedLists;
    using Microsoft.VenuGopal.Algorithms.Trees;
    using Microsoft.Venugopal.Algorithms.Common;
    using Backtracking;

    using Microsoft.Venugopal.Algorithms.Arrays;

    internal class Program
    {
        static void Main(string[] args)
        {
            IAlgoDriver driver = GetAlgorithmToExecute("RotateMatrix");
            driver.Execute();
        }

        static IAlgoDriver GetAlgorithmToExecute(string algorithHandle)
        {
            IAlgoDriver driver = null;

            switch (algorithHandle)
            {
                case "WordBreaking":
                    driver = new WordBreaking();
                    break;
                case "ReverseSLL":
                    driver = new RevereseSLL();
                    break;
                case "TreeTraversals":
                    driver = new TreeTraversals();
                    break;
                case "SpiralOrder":
                    driver = new SpiralOrder();
                    break;
                case "RotateMatrix":
                    driver = new RotateMatrix();
                    break;
            }

            return driver;
        }
    }
}
