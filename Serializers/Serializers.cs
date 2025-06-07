using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public static class Serializers
{
    public static void SerializeToBinary(Person person, string filePath)
    {
        using (var fs = new FileStream(filePath, FileMode.Create))
        using (var writer = new BinaryWriter(fs))
        {
            writer.Write(person.UserName);
            writer.Write(person.UserAge);
            
        }
    }

    public static void SerializeToXml(Person person, string filePath)
    {
        var xmlSerializer = new XmlSerializer(typeof(Person));
        using (var writer = new StreamWriter(filePath))
        {
            xmlSerializer.Serialize(writer, person);
        }
    }
    public static void SerializeToJson(Person person, string filePath)
    {
        var jsonString = JsonSerializer.Serialize<Person>(person);
        File.WriteAllText(filePath, jsonString);
    }
}