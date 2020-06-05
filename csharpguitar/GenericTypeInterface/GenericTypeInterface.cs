using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericTypeInterface
{
    public class Program
    {
        //Standard Interface
        public interface IProgram
        {
            void WriteCSharp();
            string BaseMessage { get; set; }
        }

        //Generic Interface which implements the standard interface
        public interface IProgramExtended<T> where T : IProgram
        {
            void Run(T t);
            string ExtendedMessage { get; set; }
        }

        //Class which implements standard interface
        public class MyProgram : IProgram
        {
            public void WriteCSharp()
            {
                Console.WriteLine(BaseMessage);
                Console.ReadLine();
            }

            public string BaseMessage { get; set; }
        }

        //Class which implements generic interface with class that implements standard interface
        public class MyExtendedProgram : IProgramExtended<MyProgram>
        {
            public void Run(MyProgram t)
            {
                Console.WriteLine();
                Console.WriteLine(ExtendedMessage);
                Console.WriteLine();
                t.BaseMessage = "Message from MyProgram changed by MyExtendedProgram";
                t.WriteCSharp();
            }

            public string ExtendedMessage { get; set; }
        }

        static void Main(string[] args)
        {
            MyProgram mp = new MyProgram();
            mp.BaseMessage = "Message from MyProgram";
            mp.WriteCSharp();

            MyExtendedProgram mp2 = new MyExtendedProgram();
            mp2.ExtendedMessage = "Message from MyExtendedProgram";
            mp2.Run(mp);
        }
    }
}
