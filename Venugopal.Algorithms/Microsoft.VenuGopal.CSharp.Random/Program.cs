using Microsoft.VenuGopal.CSharp.Random.Delegates;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.VenuGopal.CSharp.Random
{
    class Program
    {
        static void Main(string[] args)
        {
            Program driver = new Program();
            driver.DriverCode();
        }

        private void DriverCode()
        {
            WriteDateTimeCallback variableDelegeate = WriteDateTimeMethodOne;

            object state = (object)1234;
            ExecuteMethod(state, variableDelegeate);

            variableDelegeate = WriteDateTimeMethodTwo;
            state = (object)true;
            ExecuteMethod(state, variableDelegeate);
        }

        private void ModuleHostDriverCode()
        {
            Mock<IModuleHost> myModuleHostMock = new Mock<IModuleHost>();

            myModuleHostMock.Setup(call =>
                            call.PostOutputDataItems(
                            It.IsAny<DataItem>(),
                            It.IsAny<ModuleHostCallback.DataItemAcknowledgementCallback>(),
                            It.IsAny<object>()));

            ModuleHostCallDispatcher dispatcher = new ModuleHostCallDispatcher(myModuleHostMock.Object);

        }

        private void ExecuteMethod(object state, WriteDateTimeCallback whatCallBackToCall)
        {
            whatCallBackToCall(state);
        }
        
        //Delegate Definition One
        public delegate void WriteDateTimeCallback(object state);

        //Method for delegate
        public static void WriteDateTimeMethodOne(object state)
        {
            int value = (int)state;
            Console.WriteLine("I should get an integer value - {0}", value);
        }

        //Method for delegate Two
        public static void WriteDateTimeMethodTwo(object state)
        {
            bool value = (bool)state;
            Console.WriteLine("I should get an bool value - {0}", value);
        }
    }
}
