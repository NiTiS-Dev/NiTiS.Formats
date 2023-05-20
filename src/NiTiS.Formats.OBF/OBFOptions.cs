using System.Text;

namespace NiTiS.Formats.OBF;

public struct OBFOptions
{
	public Encoding Encoding { readonly get; set; }
	public bool AllowDisposeStream { readonly get; set; }

	public static OBFOptions Default { get; } = new()
	{
		Encoding = Encoding.UTF8,
		AllowDisposeStream = false,
	};
}