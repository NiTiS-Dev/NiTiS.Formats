using System;
using System.Buffers.Binary;

namespace NiTiS.Formats.OBF;

public partial class OBFWriter
{
	public void Write(int value)
	{
		Span<byte> buff = stackalloc byte[sizeof(int)];
		stream.WriteByte((byte)ObjectId.Int32);

		BinaryPrimitives.WriteInt32LittleEndian(buff, value);

#if NETFRAMEWORK
		NetFrameworkWrite(stream, buff);
#else
		stream.Write(buff);
#endif
	}
	public void Write(uint value)
	{
		Span<byte> buff = stackalloc byte[sizeof(uint)];
		stream.WriteByte((byte)(ObjectId.Int32 & ObjectId.FlagUnsigned));

		BinaryPrimitives.WriteUInt32LittleEndian(buff, value);

#if NETFRAMEWORK
		NetFrameworkWrite(stream, buff);
#else
		stream.Write(buff);
#endif
	}

	public void Write(long value)
	{
		Span<byte> buff = stackalloc byte[sizeof(long)];
		stream.WriteByte((byte)ObjectId.Int64);

		BinaryPrimitives.WriteInt64LittleEndian(buff, value);

#if NETFRAMEWORK
		NetFrameworkWrite(stream, buff);
#else
		stream.Write(buff);
#endif
	}
	public void Write(ulong value)
	{
		Span<byte> buff = stackalloc byte[sizeof(ulong)];
		stream.WriteByte((byte)(ObjectId.Int64 & ObjectId.FlagUnsigned));

		BinaryPrimitives.WriteUInt64LittleEndian(buff, value);

#if NETFRAMEWORK
		NetFrameworkWrite(stream, buff);
#else
		stream.Write(buff);
#endif
	}
}