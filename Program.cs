using System;

public class Program
{
    static void Main()
    {
        //Instantiate new Person object
        var mirko = new Person { UserName = "mirko", UserAge = 33 };

        // Binary Serialization
        try
        {
            Serializers.SerializeToBinary(mirko, "person.dat");
            Console.WriteLine("Binary serialization completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Binary serialization failed: {ex.Message}");
        }

        // Binary Deserialization
        try
        {
            var deserializedPerson1 = Deserializers.DeserializeFromBinary("person.dat");
            Console.WriteLine($"Binary deserialization completed. Name: {deserializedPerson1.UserName} , Age: {deserializedPerson1.UserAge}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Binary deserialization failed: {ex.Message}");
        }

        // XML Serialization
        try
        {
            Serializers.SerializeToXml(mirko, "person.xml");
            Console.WriteLine("Xml serialization completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xml serialization failed: {ex.Message}");
        }

        // XML Deserialization
        try
        {
            var deserializedPerson2 = Deserializers.DeserializeFromXml("person.xml");
            Console.WriteLine($"Xml deserialization completed. Name: {deserializedPerson2.UserName} , Age: {deserializedPerson2.UserAge} ");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xml deserialization failed: {ex.Message}");
        }

        // Json Serialization
        try
        {
            Serializers.SerializeToJson(mirko, "person.json");
            Console.WriteLine("Json serialization completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Json serialization failed: {ex.Message}");
        }

        // Json Deserialization
        try
        {
            var deserializedPerson3 = Deserializers.DeserializeFromJson("person.json");
            Console.WriteLine($"Json deserialization completed. Name: {deserializedPerson3.UserName} , Age: {deserializedPerson3.UserAge}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Json deserialization failed: {ex.Message}");
        }

    }
}