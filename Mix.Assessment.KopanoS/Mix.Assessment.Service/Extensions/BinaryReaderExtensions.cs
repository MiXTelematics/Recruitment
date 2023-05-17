namespace Mix.Assessment.Service.Extensions;

internal static class BinaryReaderExtensions
{
    internal static string ReadNullTerminatedString(this System.IO.BinaryReader br)
    {
        string str = "";
        char ch;
        while((int)(ch = br.ReadChar()) != 0)
            str = str + ch;
        return str;
    }
}
