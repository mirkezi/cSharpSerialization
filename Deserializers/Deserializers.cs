using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public static class Deserializers
{
    public static Person DeserializeFromBinary(string filePath)
    {
        using (var fs = new FileStream(filePath, FileMode.Open)) 
        using (var reader = new BinaryReader(fs))
        return new Person
        {
            UserName = reader.ReadString(),
            UserAge = reader.ReadInt32(),
        };
    }
    
    public static Person DeserializeFromXml(string filePath)
    {
        var xmlSerializer = new XmlSerializer(typeof(Person));
        using (var reader = new StreamReader(filePath))
            return (Person)xmlSerializer.Deserialize(reader);

    }
    
    public static Person DeserializeFromJson(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Person>(jsonString);
    }
}