using System;
using System.Buffers.Binary;
using System.Numerics;

namespace NiTiS.Formats.OBF;

public partial class OBFWriter
{
	public unsafe void Write(float value)
	{
		Span<byte> buff = stackalloc byte[sizeof(float)];
		stream.WriteByte((byte)ObjectId.Real32);

		BinaryPrimitives.WriteUInt32LittleEndian(buff, *(uint*)&value);

#if NETFRAMEWORK
		BinaryPrimitives.WriteUInt32LittleEndian(buff, *(uint*)&value);
		NetFrameworkWrite(stream, buff);
#elif NETSTANDARD
		BinaryPrimitives.WriteUInt32LittleEndian(buff, *(uint*)&value);
		stream.Write(buff);
#else
		BinaryPrimitives.WriteSingleLittleEndian(buff, value);
		stream.Write(buff);
#endif
	}
	public unsafe void Write(double value)
	{
		Span<byte> buff = stackalloc byte[sizeof(double)];
		stream.WriteByte((byte)ObjectId.Real64);


#if NETFRAMEWORK
		BinaryPrimitives.WriteUInt64LittleEndian(buff, *(ulong*)&value);
		NetFrameworkWrite(stream, buff);
#elif NETSTANDARD
		BinaryPrimitives.WriteUInt64LittleEndian(buff, *(ulong*)&value);
		stream.Write(buff);
#else
		BinaryPrimitives.WriteDoubleLittleEndian(buff, value);
		stream.Write(buff);
#endif
	}
}