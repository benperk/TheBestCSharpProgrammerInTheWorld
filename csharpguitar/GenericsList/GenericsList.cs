using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using static System.Console;

namespace Generics
{
    public class GenericsList<T> : IEnumerable<T>
    { 
        protected Element head;
        protected Element current = null;

        protected class Element
        {
            public Element nextElement {get; set;}
            public T elementData { get; set; }

            public Element(T t)
            {
                nextElement = null;
                elementData = t;
            }
        }

        public GenericsList() { head = null; }

        public void AddElementToList(T t)
        {
            Element element = new Element(t);
            element.nextElement = head;
            head = element;
        }

        //Must implement the GetEnumerator() method when IEnumerable<T> is implemented
        //This method allows use to use the foreach statement in our Main program.
        public IEnumerator<T> GetEnumerator()
        {
            Element current = head;
            while (current != null)
            {
                yield return current.elementData;
                current = current.nextElement;
            }
        }

        // We must implement this method when IEnumerable<T> is implemented
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class BankBalance
    {
        string accountNumber;
        double accountBalance;

        public BankBalance(string acctNum, double acctBal)
        {
            accountNumber = acctNum;
            accountBalance = acctBal;
        }

        public override string ToString()
        {
            return accountNumber + "\t:\t" + accountBalance;
        }
    }
   
    class GenericsProgram
    {
        static void Main(string[] args)
        {
            GenericsList<BankBalance> list = new GenericsList<BankBalance>();

            //Create accountNumber and accountBalance values to initialize BankBalance objects.
            string[] accountNumber = new string[] { "A12345-98", "B34565-64", "L98756-32", "S3847D-22", "F8475T-T5", "BL0923-K8", "Q789FD-O4", "B34565-01", "A23-JHG23", "MK987-Z4R" };
            double[] accountBalance = new double[] { 125.12, 748.54, 42343.56, 3243.78, 127890.44, 1.45, 9876.98, 453.54, 7435.76, 234.75 };

            //Populate the list.
            for (int row = 0; row < accountNumber.Length; row++)
            {
                list.AddElementToList(new BankBalance(accountNumber[row], accountBalance[row]));
            }

            WriteLine("Bank Account Balance List:");
            foreach (BankBalance b in list)
            {
                WriteLine(b.ToString());
            }

            ReadLine();
        }
    }
}
