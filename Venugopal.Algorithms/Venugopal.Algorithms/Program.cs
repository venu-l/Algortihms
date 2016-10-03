namespace Microsoft.Venugopal.Algorithms
{
    using System.Collections;
    using System.Diagnostics;
    using Microsoft.Venugopal.Algorithms.LinkedLists;
    using Microsoft.VenuGopal.Algorithms.Trees;
    using Microsoft.Venugopal.Algorithms.Common;
    using Backtracking;

    internal class Program
    {
        static void Main(string[] args)
        {
            IAlgoDriver driver = GetAlgorithmToExecute("TreeTraversals");

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
            }

            return driver;
        }
    }
}
