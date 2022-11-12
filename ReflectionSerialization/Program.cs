using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

List<Person> persons = new List<Person>{
    new Person(1) { Name = "Victor", Age = 50 },
    new Person(2) { Name = "Maxim", Age = 50 },
    new Person(3) { Name = "Daniela", Age = 50 },
    new Person(4) { Name = "Alex", Age = 50 }
};


XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));

using (var fstream = File.Create("test.xml"))
{
    formatter.Serialize(fstream, persons);
    Console.WriteLine("person added to file");
}

var fstream2 = File.OpenRead("test.xml");
List<Person> persons2 = (List<Person>)formatter.Deserialize(fstream2);

foreach(var p in persons2)
Console.WriteLine(p.ToString());


[Serializable]
public class Person 
{
    int _id;

    public string Name { get; set; }
    public int Age { get; set; }
    public string Details = "info";

    public Person(int id)
    {
        _id = id;
    }

    public Person()
    {
        _id = 1;
    }

    public override string ToString()
    {
        return $"Id: {_id} - Name: {Name} - Age: {Age} - {Details} ";
    }
}





