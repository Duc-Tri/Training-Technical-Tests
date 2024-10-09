using System.Reflection;

Console.Title = "LEARNING REFLECTION";

//string name = "Kevin";
//var stringType = name.GetType(); // typeof
//Console.WriteLine("Hello, World! "+ stringType);

var currentAssembly = Assembly.GetExecutingAssembly();
var typesFromCurrentAssembly = currentAssembly.GetTypes();
foreach (var type in typesFromCurrentAssembly)
{
    Console.WriteLine(type.Name);
}

var oneTypeFromCurrentAssembly = currentAssembly.GetType("ReflectionSample.Person");
var externaleAssembly = Assembly.Load("System.Text.Json");
var typesFromExternalAssembly = externaleAssembly.GetTypes();
var oneTypeFromExternalAssembly= externaleAssembly.GetType("System.Text.Json.JsonProperty");

var modulesFromExternalAssembly = externaleAssembly.GetModules();
var oneModuleFromExternalAssembly = externaleAssembly.GetModule("System.Text.Json.dll");

var typesFromModuleFromExternalAssembly = oneModuleFromExternalAssembly.GetTypes();
var oneTypeFromModuleFromExternalAssembly = oneModuleFromExternalAssembly.GetType("System.Text.Json.JsonProperty");



Console.ReadLine();
