using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

public class Program
{
    public class Person
    {
        public string UserName { get; set; }
        public int UserAge { get; set; }
    }

    static void Main()
    {
        //Instantiate new Person object
        var mirko = new Person { UserName = "Mirko", UserAge = 33 };

        // Binary Serialization
        try
        {
            using (var fs = new FileStream("person.dat", FileMode.Create))
            using (var writer = new BinaryWriter(fs))
            {
                writer.Write(mirko.UserName);
                writer.Write(mirko.UserAge);
                Console.WriteLine("Binary serialization completed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Binary serialization failed: {ex.Message}");
        }

        // Binary Deserialization
        try
        {
            using (var fs = new FileStream("person.dat", FileMode.Open))
            using (var reader = new BinaryReader(fs))
            {
                var deserializedPerson1 = new Person
                {
                    UserName = reader.ReadString(),
                    UserAge = reader.ReadInt32(),
                };
                Console.WriteLine($"Binary deserialization completed. Name: {deserializedPerson1.UserName} , Age: {deserializedPerson1.UserAge}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Binary deserialization failed: {ex.Message}");
        }

        // XML Serialization
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));
            using (var writer = new StreamWriter("person.xml"))
            {
                xmlSerializer.Serialize(writer, mirko);
                Console.WriteLine("Xml serialization completed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xml serialization failed: {ex.Message}");
        }

        // XML Deserialization
        try
        {
            var xmlSerializer = new XmlSerializer(typeof(Person));
            using (var reader = new StreamReader("person.xml"))
            {
                var deserializedPerson2 = (Person)xmlSerializer.Deserialize(reader);
                Console.WriteLine($"Xml deserialization completed. Name: {deserializedPerson2.UserName} , Age: {deserializedPerson2.UserAge}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xml deserialization failed: {ex.Message}");
        }

        // Json Serialization
        try
        {
            var jsonString = JsonSerializer.Serialize(mirko);
            File.WriteAllText("person.json", jsonString);
            Console.WriteLine("Json serialization completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Json serialization failed: {ex.Message}");
        }

        // Json Deserialization
        try
        {
            var jsonString = File.ReadAllText("person.json");
            var deserializedPerson3 = JsonSerializer.Deserialize<Person>(jsonString);
            Console.WriteLine($"Json deserialization completed. Name: {deserializedPerson3.UserName} , Age: {deserializedPerson3.UserAge}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Json deserialization failed: {ex.Message}");
        }
    }
}