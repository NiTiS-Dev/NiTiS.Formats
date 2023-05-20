using NiTiS.Core.Extensions;
using NiTiS.Formats.OBF;
using System;
using System.IO;

internal class Program
{
	private static void Main(string[] args)
	{
		//using FileStream fs = new(@"C:\Desktop\a.obf", FileMode.OpenOrCreate);
		using MemoryStream fs = new();
		using OBFWriter writer = new(fs, OBFOptions.Default);

		writer.Write(1d);

        Console.WriteLine(fs.ToArray().ArrayToString());
    }
}