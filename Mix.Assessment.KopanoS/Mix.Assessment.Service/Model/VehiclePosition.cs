using System.Runtime.InteropServices;
using System.Text;

namespace Mix.Assessment.Service.Model;

public struct VehiclePosition
{
    public int VehicleId { get; set; }
    public string? VehicleRegistration { get; set; }
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public Int64 RecordedTimeUTC { get; set; }

    /// <summary>
    /// Error on Marshal => Access Violation OR invalid Bytes
    /// </summary>
    /// <param name="fs"></param>
    /// <returns></returns>
    internal static VehiclePosition FromFileStream(FileStream fs)
    {
        byte[] buff = new byte[VPSize.Size];
        int amt = 0;
        while(amt < buff.Length)
            amt += fs.Read(buff,amt,buff.Length - amt);
        GCHandle handle = GCHandle.Alloc(buff,GCHandleType.Pinned);
        VehiclePosition vp = (VehiclePosition)Marshal.PtrToStructure(handle.AddrOfPinnedObject(),typeof(VehiclePosition));
        handle.Free();
        return vp;
    }

    internal static VehiclePosition FromBinaryReaderField(BinaryReader br)
    {
        VehiclePosition vp = new VehiclePosition();
        try
        {
            vp.VehicleId = br.ReadInt32();
            vp.VehicleRegistration = br.ReadNullTerminatedString();
            vp.Latitude = br.ReadSingle();
            vp.Longitude = br.ReadSingle();
            vp.RecordedTimeUTC = br.ReadInt64();
        }
        catch(Exception ex)
        {
            Console.Write(ex.Message);
        }
        return vp;
    }
}


