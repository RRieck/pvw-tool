using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;
using StartUp.Model;
using Path = System.Windows.Shapes.Path;

namespace StartUp.Datenhaltung
{
    public class XmlParser
    {
        readonly string _path;
        
        public XmlParser()
        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Initialize();
        }
        

        public List<Model.Employee> ReadFile()
        {
            var xdoc = GetXDocStream();

            var test =  xdoc.Descendants("Personen")
                      .Descendants("Person")
                      .Select(item => new Employee()
                      {
                            Id = item.Attribute("Name").Value,
                            Name = string.Concat(item.Descendants("Vorname").First().Value, " ", item.Descendants("Nachname").First().Value),
                            Abteilung = item.Descendants("Abteilung").First().Value
                      })
                      .ToList();

            return test;
        }

        public void WriteNewEntry(Employee employee)
        {
            var prename = employee.Name.Split(new[]{' '}, StringSplitOptions.None).First();
            var lastname = employee.Name.Split(new[]{' '}, StringSplitOptions.None).Last();

            var xdoc = GetXDocStream();
            xdoc.Elements("Personen")
                .First().Add(new XElement("Person", new XAttribute("Name", employee.Name), 
                                   new XElement("Vorname", prename), 
                                   new XElement("Nachname", lastname),
                                   new XElement("Abteilung", employee.Abteilung)));
            
            xdoc.Save(_path + @"\TestFile.xml");
        }

        XDocument GetXDocStream()
        {
            return XDocument.Load(_path + @"\TestFile.xml");
        }

        void Initialize()
        {
            CheckIfFileExists(_path + @"\TestFile.xml");
        }

        void CheckIfFileExists(string filePath)
        {
            if (!File.Exists(filePath)){
                File.Create(filePath).Close();
                File.WriteAllText(filePath, AddRootElement());
            }
        }

        string AddRootElement()
        {
            return string.Concat("<?xml version=", "\"1.0\"", " encoding=", "\"utf-8\"", "?>","<Personen>","</Personen>");
        }
    }
}
