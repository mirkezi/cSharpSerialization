# cSharpSerialization

Welcome to my C# Serialization repository.
I've created it to display new knowledge achieved through the Microsoft Back-End Developer professional certificate.

# Project Requirements:

1. Functional:
    The application has to serialized a c# object into Json, Xml, Binary and deserialize it into c# objects.
2. Non-Functional:
    Data should be store into respective files during processes.

# Application Design:

1. Person.cs file storing the Person Class that will be used by the application.
2. Serializers.cs file handling serialization methods to Json, Xml, Binary creating a dedicated file for each format.
3. Deserializers.cs file reading serialized data previously store into dedicated files and handling deserialization methods.
4. Program.cs file will have the Main() method instantiating a new Person Object, use it as argument for serialization methods,
    call deserializers method and display to console return data. Every method must have a try-catch block ensuring Exception verification.
