using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IsogradC_08.Question;

namespace IsogradC_08
{
    public class Question
    {
        public class User
        {
            public string FirstName { get; set; }
            public string LasstName { get; set; }
        }

        /*
        <?xml version = "1.0" encoding="utf-8".>
        <Users>
            <User FirstName = "Marc" LastName="Martin"/>
            <Users FirstName = "John" LastName="Smith"/>
        </Users>
        */

        public IEnumerable<User> GetUsers(string xmlFilePath)
        {
            //-----------------------------------------------------------------
            return null;
            //-----------------------------------------------------------------
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
