using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;

namespace NiTiS.Formats.OBF;

public partial class OBFWriter : IDisposable
{
	protected Stream stream;
	protected readonly OBFOptions options;

	public OBFWriter(Stream stream)
		: this(stream, OBFOptions.Default) { }
	public OBFWriter(Stream stream, OBFOptions options)
	{
		this.stream = stream;
		this.options = options;
	}

	public void Dispose()
	{
		if (options.AllowDisposeStream)
			stream?.Dispose();

		stream = null!;
	}

#if NETFRAMEWORK
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected static void NetFrameworkWrite(Stream stream, Span<byte> span)
	{
		byte[]? array = null;
		try
		{
			array = ArrayPool<byte>.Shared.Rent(span.Length);

			span.CopyTo(array);
			stream.Write(array, 0, span.Length);
		}
		finally
		{
			if (array is not null)
				ArrayPool<byte>.Shared.Return(array);
		}
	}
#endif
}