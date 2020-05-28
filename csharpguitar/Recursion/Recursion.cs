using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;

namespace RecursiveXML
{
    class Program
    {
        //Simple recursive display of an XML document (depth is an optional parameter)
        public static void Process(XElement element, int depth = 0)
        {
            if (!element.HasElements)
            {
                //No elements means that we have reached the end of the branch, I.e. no more child
                Console.WriteLine(string.Format("{0}{1}", "".PadLeft(depth, '\t'), element.FirstAttribute.Value));
            }
            else
            {
                //The current element has children
                Console.WriteLine("".PadLeft(depth, '\t') + element.FirstAttribute.Value);

                foreach (XElement child in element.Elements())
                {
                    Process(child, depth + 1);
                }
            }
        }

        static void Main(string[] args)
        {
            Process(XDocument.Load("C:\\orders.xml").Root);
           
            Console.ReadLine();

            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();

            XDocument.Load("C:\\orders.xml").Root.RecursiveProcess
            (
                //Do something to the child here
                new Action<XElement, int>((child, depth) =>
                {
                    sb1.Append(child.FirstAttribute.Value + ".");
                    Console.WriteLine(string.Format("{0}{1}", "".PadLeft(depth, '\t'), child.FirstAttribute.Value));
                }),

                //DO something when the parent is opened
                new Action<XElement, int>((parent, depth) =>
                {
                    sb2.Append(parent.FirstAttribute.Value + ".");
                    Console.WriteLine(string.Format("{0}{1}", "".PadLeft(depth, '\t'), parent.FirstAttribute.Value));
                }),

                //do something when the parent is closed
                new Action<XElement, int>((parent, depth) =>
                {
                    sb3.Append(parent.FirstAttribute.Value + ".");
                    Console.WriteLine(string.Format("{0}{1}", "".PadLeft(depth, '\t'), parent.FirstAttribute.Value));
                })
            );

            Console.ReadLine();

            Console.WriteLine(sb1.ToString());
            Console.WriteLine(sb2.ToString());
            Console.WriteLine(sb3.ToString());

            Console.ReadLine();
        }
    }

    public static class XRecursion
    {
        public static void RecursiveProcess(this XElement element, Action<XElement, int> childMethod,
                                              Action<XElement, int> parentOpenMethod, Action<XElement, int> parentCloseMethod)
        {
	        if (element == null)
	        {
	            throw new ArgumentNullException("element");
	        }

            element.RecursiveProcess(childMethod, parentOpenMethod, parentCloseMethod, 0);
	    }

        private static void RecursiveProcess(this XElement element, Action<XElement, int> childMethod,
                                               Action<XElement, int> parentOpenMethod, Action<XElement, int> parentCloseMethod, int depth = 0)
        {
	        if (element == null)
	        {
	            throw new ArgumentNullException("element");
	        }
	 
	        if (!element.HasElements)
	        {
	            // Reached the deepest child	 
                if (childMethod != null)
	            {
                    childMethod(element, depth + 1);
	            }
	        }
	        else
	        {
	            // element has children	 
                if (parentOpenMethod != null)
	            {
                    parentOpenMethod(element, depth + 1);
	            }
	 
	            foreach (XElement child in element.Elements())
	            {
                    child.RecursiveProcess(childMethod, parentOpenMethod, parentCloseMethod, depth + 1);
	            }

                if (parentCloseMethod != null)
	            {
                    parentCloseMethod(element, depth + 1);
	            }
	        }
	    }
    }
}
