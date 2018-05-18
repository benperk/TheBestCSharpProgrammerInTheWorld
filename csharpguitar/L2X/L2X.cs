using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;
using System.IO;

using static System.Console;

namespace L2X
{
    class Program
    {
        static void Main(string[] args)
        {
            if(File.Exists("L2XML.xml"))
            {
                WriteLine("XML file L2XML.xml already exists.");
            }
            else
            {
                try
                {
                    XElement L2XML =
                      new XElement("configuration",
                        new XElement("default",
                          new XAttribute("key", "language"),
                          new XAttribute("value", "de-DE")
                        )
                      );


                    L2XML.Save("L2XML.xml");
                    .WriteLine("XML file saved");
                }
                catch (InvalidOperationException e)
                {
                    WriteLine();
                    WriteLine(e.Message);
                }
            }



            if (File.Exists("L2XML.xml"))
            {
                string language = string.Empty;
                try
                {
                    //Read from XML file using LINQ to XML with Lambda
                    language = XElement.Load("L2XML.xml")
                                       .Elements("default")
                                       .Where(el => el.Attribute("key").Value == "language")
                                       .Select(el => el.Attribute("value").Value)
                                       .Single();

                    WriteLine();
                    WriteLine("The value stored in the default element within the language key is: " + language);

                    WriteLine();
                    WriteLine("Adding a new language...");
                }
                catch (InvalidOperationException e)
                {
                    WriteLine();
                    WriteLine(e.Message);
                }

                XElement xmlDoc = XElement.Load("L2XML.xml");
                try
                {
                    //Add to XML file using LINQ to XML
                    //XElement xmlDoc = XElement.Load("L2XML.xml");
                    XElement newQuery =
                      new XElement("default",
                        new XAttribute("key", "language2"),
                        new XAttribute("value", "es-ES")
                      );
                    xmlDoc.Add(newQuery);
                    xmlDoc.Save("L2XML.xml");

                    //Read from XML file using LINQ to XML with Lambda
                    string language2 = XElement.Load("L2XML.xml")
                                               .Elements("default")
                                               .Where(el => el.Attribute("key").Value == "language2")
                                               .Select(el => el.Attribute("value").Value)
                                               .Single();

                    WriteLine();
                    WriteLine("Language: " + language2 + " was added to the XML file");
                }
                catch (InvalidOperationException e)
                {
                    WriteLine();
                    WriteLine(e.Message);
                }

                string newLanguage = string.Empty;
                if (language == "de-DE")
                {
                    newLanguage = "fr-FR";
                }
                else
                {
                    newLanguage = "de-DE";
                }

                try
                {
                    //Modify existing keys' value using LINQ to XML with Lambda
                    xmlDoc.Elements("default")
                          .Where(el => el.Attribute("key").Value == "language")
                          .Single()
                          .SetAttributeValue("value", newLanguage);

                    xmlDoc.Save("L2XML.xml");

                    //Read from XML file using LINQ to XML with Lambda
                    string language3 = XElement.Load("L2XML.xml")
                                               .Elements("default")
                                               .Where(el => el.Attribute("key").Value == "language")
                                               .Select(el => el.Attribute("value").Value)
                                               .Single();

                    WriteLine();
                    WriteLine("Language: " + language + " was updated to: " + language3);
                }
                catch (InvalidOperationException e)
                {
                    WriteLine();
                    WriteLine(e.Message);
                }
            }
            else
            {
                WriteLine();
                WriteLine("XML file does not exist.  Good-bye.");
            }

            ReadLine();
        }
    }
}
