using System;
using System.Buffers.Binary;

namespace NiTiS.Formats.OBF;

public partial class OBFWriter
{
	public unsafe void Write(ReadOnlySpan<char> value)
	{
		Span<byte> buff = stackalloc byte[4];
		stream.WriteByte((byte)ObjectId.String);

		byte[] encoded = options.Encoding.GetBytes(value.ToString());

		BinaryPrimitives.WriteInt32LittleEndian(buff, encoded.Length);
#if NETFRAMEWORK
		NetFrameworkWrite(stream, buff);

		NetFrameworkWrite(stream, encoded);
#else
		stream.Write(buff);

		stream.Write(encoded);
#endif
	}
	public unsafe void Write(string value)
	{
		Span<byte> buff = stackalloc byte[4];
		stream.WriteByte((byte)ObjectId.String);

		byte[] encoded = options.Encoding.GetBytes(value);

		BinaryPrimitives.WriteInt32LittleEndian(buff, encoded.Length);
#if NETFRAMEWORK
		NetFrameworkWrite(stream, buff);

		stream.Write(encoded, 0, encoded.Length);
#else
		stream.Write(buff);

		stream.Write(encoded);
#endif
	}
}