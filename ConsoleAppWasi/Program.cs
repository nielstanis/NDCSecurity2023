
using System.Runtime.InteropServices;

Console.WriteLine($"Hello NDC Security 2023 from {RuntimeInformation.OSArchitecture}!");

var content = System.IO.File.ReadAllText("/etc/hosts");
Console.WriteLine(content);

