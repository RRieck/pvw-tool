using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using StartUp.Infrastructure.Extensions;
using StartUp.Model;

namespace StartUp.Datenhaltung
{
    public class XmlParser
    {
        readonly string _path;
        readonly string _fileName;

        public XmlParser()
        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _fileName = @"\TestFile.xml";
            Initialize();
        }

        void Initialize()
        {
            CheckIfFileExists(_path + _fileName);
        }

        public List<Model.Employee> ReadFile()
        {
            var xdoc = GetXDocStream();

            var test = xdoc.Descendants("Personen")
                      .Descendants("Person")
                      .Select(item => new Employee()
                      {
                          Id = item.Attribute("ID").Value,
                          Name = string.Concat(item.Descendants("Vorname").First().Value, " ", item.Descendants("Nachname").First().Value),
                          Abteilung = item.Descendants("Abteilung").First().Value
                      })
                      .ToList();

            return test;
        }

        public void WriteNewEntry(Employee employee)
        {
            var prename = NameParser.ReceivePreAndLastname(employee.Name).First();
            var lastname = NameParser.ReceivePreAndLastname(employee.Name).Last();

            var xdoc = GetXDocStream();
            var uniqueId = IdCreator.Generate();
            if (!CheckIfEntryExists(uniqueId.ToString()))
            {
                xdoc.Elements("Personen")
                    .First().Add(new XElement("Person", new XAttribute("ID", IdCreator.Generate()),
                                       new XElement("Vorname", prename),
                                       new XElement("Nachname", lastname),
                                       new XElement("Abteilung", employee.Abteilung)));
            }
            xdoc.Save(_path + _fileName);
        }

        public void ChangeExistingEntry(Employee changedEmployee)
        {
            var prename = NameParser.ReceivePreAndLastname(changedEmployee.Name).First();
            var lastname = NameParser.ReceivePreAndLastname(changedEmployee.Name).Last();

            var xdoc = GetXDocStream();

            if (CheckIfEntryExists(changedEmployee.Id))
            {
                var element = xdoc.Root.Elements("Person").Where(entry => entry.Attribute("ID").Value.Equals(changedEmployee.Id));
                element.First().Element("Vorname").Value = prename;
                element.First().Element("Nachname").Value = lastname;
                element.First().Element("Abteilung").Value = changedEmployee.Abteilung;
            }
            xdoc.Save(_path + _fileName);
        }

        public void DeleteEntry(string id)
        {
            var xdoc = GetXDocStream();
                
            xdoc.Descendants("Person")
                .Where(x => x.Attribute("ID").Value == id)
                .Remove();

            xdoc.Save(_path + _fileName);
        }

        XDocument GetXDocStream()
        {
            try{
               return XDocument.Load(_path + _fileName);
            }
            catch (Exception e){
                Debug.WriteLine(e.Message);
                throw;
            }
        }
        
        string AddRootElement()
        {
            return string.Concat("<?xml version=", "\"1.0\"", " encoding=", "\"utf-8\"", "?>", "\n<Personen>", "\n</Personen>");
        }

        void CheckIfFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                File.WriteAllText(filePath, AddRootElement());
            }
        }

        bool CheckIfEntryExists(string id)
        {
            var xdoc = GetXDocStream();
            var el = xdoc.Root.Elements("Person").Where(x => x.Attribute("ID").Value == id);
            var test = el.Count();

            if (test > 0)
                return true;

            return false;
        }
    }
}
