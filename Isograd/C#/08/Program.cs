using System.Collections.Generic;
using static IsogradC_08.Question;
using System.Xml;
using System;

namespace IsogradC_08
{
    public class Question
    {
        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public override string ToString()
            {
                return "USER " + FirstName + ", " + LastName;
            }
        }

        /*
        <?xml version="1.0" encoding="utf-8"?>
        <Users>
            <User FirstName="Marc" LastName="Martin" />
            <User FirstName="John" LastName="Smith" />
        </Users>
        */

        public IEnumerable<User> GetUsers(string xmlFilePath)
        {
            //-----------------------------------------------------------------
            List<User> users = new List<User>();
            XmlReader reader = new XmlTextReader(xmlFilePath);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        //Console.Write("<" + reader.Name);

                        if (reader.Name.Equals("User"))
                        {
                            User u = new User();
                            while (reader.MoveToNextAttribute()) // Read the attributes.
                            {
                                if (reader.Name.Equals("FirstName"))
                                    u.FirstName = reader.Value;
                                else if (reader.Name.Equals("LastName"))
                                    u.LastName = reader.Value;
                            }
                            Console.WriteLine(u);
                        }
                        break;

                    case XmlNodeType.Text: //Display the text in each element.
                        Console.WriteLine("*** " + reader.Value);
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element.
                        //Console.Write("</" + reader.Name);
                        break;
                }

            }

            return users;
            //-----------------------------------------------------------------
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            (new Question()).GetUsers("..\\..\\users.xml");
        }
    }
}
