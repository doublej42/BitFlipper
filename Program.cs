// See https://aka.ms/new-console-template for more information
//Get Filename from console
//Read in the in file and flip it's bit order
//Save the file to string.reverse if target does not already exist
//.... profit?
const byte allOne = 255;
var filename = Path.GetFullPath(args[0]);

Console.WriteLine($"Bit flipping {filename}");
var targetFile = Path.Combine(Path.GetDirectoryName(filename) , new String(Path.GetFileName(filename).ToCharArray().Reverse().ToArray()));
Console.WriteLine($"Writing output to {targetFile}");  
if (File.Exists(targetFile))
{
    Console.WriteLine("Target already exists");
    return;
}
using var inFile = File.OpenRead(filename);
using var outFile = File.Create(targetFile);
var inByte = inFile.ReadByte();

while(inByte != -1)
{
    var inBits = ((byte)inByte);
    byte flipped = (byte)(inBits ^ allOne);
    outFile.WriteByte(flipped);
    inByte = inFile.ReadByte();
}


