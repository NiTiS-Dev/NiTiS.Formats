using System;
using System.IO;

namespace NiTiS.Formats.OBF.NUnitTests;

public class WriterTest
{
	private static readonly byte[] empty = Array.Empty<byte>();
	private static readonly byte[] stringHelloWorld = new byte[] { (byte)ObjectId.String, 11, 0, 0, 0, 0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x57, 0x6f, 0x72, 0x6c, 0x64, };
	private static readonly byte[] floatDoubleZeroOne = new byte[] { (byte)ObjectId.Real32, 0, 0, 0, 0, (byte)ObjectId.Real64, 0b0, 0b0, 0b0, 0b0, 0b0, 0b0, 0b11110000, 0b00111111 };

	[Test]
	public void EmptyCheck()
	{
		using MemoryStream stream = new();
		using OBFWriter writer = new(stream);

		Assert.That(stream.ToArray(), Is.EqualTo(empty));
	}

	[Test]
	public void StringCheck()
	{
		using MemoryStream stream = new();
		using OBFWriter writer = new(stream);
		writer.Write("Hello World");

		Assert.That(stream.ToArray(), Is.EqualTo(stringHelloWorld));
	}
	[Test]
	public void StringSpanCheck()
	{
		using MemoryStream stream = new();
		using OBFWriter writer = new(stream);
		writer.Write("Hello World".AsSpan());

		Assert.That(stream.ToArray(), Is.EqualTo(stringHelloWorld));
	}
	[Test]
	public void FloatDoubleCheck()
	{
		using MemoryStream stream = new();
		using OBFWriter writer = new(stream);
		writer.Write(0f);
		writer.Write(1d);

		Assert.That(stream.ToArray(), Is.EqualTo(floatDoubleZeroOne));
	}
}