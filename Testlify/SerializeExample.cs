using System.Runtime.Serialization.Formatters.Binary;

namespace StarChainGazerTest
{
    [Serializable]
    class Person
    {
        int Age;
        string City;

        public Person(int age, string city)
        {
            Age = age;
            City = city;
        }
    }

    public class SerializeExample
    {
        public static void Main(string[] args)
        {
            FileStream stream = new FileStream("d:\\abcd.txt", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            Person s = new Person(24, "EVE");
            formatter.Serialize(stream, s);
            stream.Close();
        }
    }

}