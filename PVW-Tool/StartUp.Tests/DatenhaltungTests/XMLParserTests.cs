using Microsoft.VisualStudio.TestTools.UnitTesting;
using StartUp.Datenhaltung;

namespace StartUp.Tests.DatenhaltungTests
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class XMLParserTests
    {
        public string XmlFile =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
            "<Personen>\r\n" +
            "  <Person ID=\"08a568fc-ac43-4950-8813-0891937600d2\">\r\n" +
            "    <Vorname>Johannes-Carl</Vorname>\r\n" +
            "    <Nachname>Kunz</Nachname>\r\n" +
            "    <Abteilung>Front-End</Abteilung>\r\n" +
            "  </Person>\r\n" +
            "  <Person ID=\"11561bf6-345c-435a-ab45-86f975f22468\">\r\n" +
            "    <Vorname>Maximilian</Vorname>\r\n" +
            "    <Nachname>Mahlke</Nachname>\r\n" +
            "    <Abteilung>Business-Logik</Abteilung>\r\n" +
            "  </Person>\r\n" +
            "  <Person ID=\"6b818ee8-8cd2-4036-821d-2d021f3da60b\">\r\n" +
            "    <Vorname>Ron</Vorname>\r\n" +
            "    <Nachname>Rieck</Nachname>\r\n" +
            "    <Abteilung>Die neue IT Abteilung</Abteilung>\r\n" +
            "  </Person>\r\n" +
            "</Personen>";

        XmlParser _parser = new XmlParser();
        
        [TestMethod]
        public void ReadFileAndGetBack3Elements()
        {
            Assert.AreEqual(3, _parser.GetEmployees().Count);
        }
    }
}
