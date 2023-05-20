namespace NiTiS.Formats.OBF;

public enum ObjectId : byte
{
	// std 2023x1
	Object = 0,
	String = 1,
	Int32 = 2,
	Int64 = 3,
	Real32 = 4,
	Real64 = 5,
	FlagUnsigned = 0xF0,
}
