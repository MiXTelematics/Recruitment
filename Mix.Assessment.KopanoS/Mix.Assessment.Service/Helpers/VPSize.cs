
using Mix.Assessment.Service.Model;
using System.Runtime.InteropServices;

internal sealed class VPSize
{
    internal static int _size;

    static VPSize()
    {
        _size = Marshal.SizeOf(typeof(VehiclePosition));
    }

    internal static int Size
    {
        get
        {
            return _size;
        }
    }
}
