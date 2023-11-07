using System.Reflection;

namespace StarChainGazerTest
{
    class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }

        public Student()
        {
            RollNo = 0;
            Name = string.Empty;
        }

        public Student(int rno, string n)
        {
            RollNo = rno;
            Name = n;
        }

        public void displayData()
        {
            Console.WriteLine(RollNo);
            Console.WriteLine(Name);
        }
    }

    class Reflection_Metadata
    {
        static void Main(string[] args)
        {
            Assembly executing = Assembly.GetExecutingAssembly();
            Type[] types = executing.GetTypes();
            int i = 1;
            foreach (var item in types)
            {
                MethodInfo[] methods = item.GetMethods();
                foreach (var method in methods)
                {
                    i++;
                    Console.WriteLine(item.Name + " >>> " + method.Name);
                    if (i > 1)
                        break;
                }
            }
        }
    }

}


/*
 EmbeddedAttribute >>> Equals
NullableAttribute >>> Equals
NullableContextAttribute >>> Equals
Student >>> get_RollNo
GFG >>> GetType
*/