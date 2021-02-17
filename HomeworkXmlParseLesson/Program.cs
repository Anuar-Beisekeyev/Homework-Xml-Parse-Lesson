using System;
using System.Collections.Generic;
using System.Xml;

namespace HomeworkXmlParseLesson
{
    class Program
    {
        // public static readonly int ROUTE_ELEMENT_POSITION = 0;
        static void Main(string[] args)
        {
            var list = new List<Item>();
            var xmlDocument = new XmlDocument();
            xmlDocument.Load("https://habrahabr.ru/rss/interesting/");

            var itemListElement = xmlDocument.DocumentElement;

            foreach(XmlElement itemElement in itemListElement.ChildNodes)
            {
                foreach(XmlElement chanelElement in itemElement.ChildNodes)
                {
                    if(chanelElement.Name == "item")
                    {
                        var item = new Item();
                        foreach(XmlElement element in chanelElement.ChildNodes)
                        {
                            switch (element.Name)
                            {
                                case "title":
                                    item.Title = element.InnerText;
                                    break;
                                case "description":
                                    item.Description = element.InnerText;
                                    break;
                                case "link":
                                    item.Link = element.InnerText;
                                    break;
                                case "pubDate":
                                    item.PubDate = element.InnerText;
                                    break;
                            }
                        }
                        list.Add(item);
                    }
                }
            }

            var studentList = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Керимов Самат",
                    Age = 18,
                    Group = "ЭN - 55",
                    AverageScore = 10.5

                },
                new Student
                {
                    Id = 2,
                    Name = "Жакупов Марат",
                    Age = 19,
                    Group = "CT - 119",
                    AverageScore = 9                    
                }
            };
            var stXmlDocument = new XmlDocument();
            var xmlDeclaration = stXmlDocument.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
            stXmlDocument.AppendChild(xmlDeclaration);
            var routeElement = stXmlDocument.CreateElement("studentList");
            stXmlDocument.AppendChild(routeElement);

            foreach (var student in studentList)
            {
                var studentElement = stXmlDocument.CreateElement("student");
                studentElement.SetAttribute("id", student.Id.ToString());
                studentElement.SetAttribute("name", student.Name);
                studentElement.SetAttribute("age", student.Age.ToString());
                studentElement.SetAttribute("group", student.Group);
                studentElement.SetAttribute("average_score", student.AverageScore.ToString());
                routeElement.AppendChild(studentElement);
            }

            stXmlDocument.Save("Student.txt");
        }
    }
}
