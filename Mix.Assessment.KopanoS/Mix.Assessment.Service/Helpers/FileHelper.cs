
using Mix.Assessment.Service.Model;

namespace Mix.Assessment.Service.Helpers
{
    internal class FileHelper
    {
        protected VehiclePosition data;
        protected string fileName;
        private FileStream fs;
        private BinaryReader br;
        private long length = -1;
        protected bool open = false;
        private long position = 0;
        private bool useCachedValues = false;

        internal FileHelper(string FName)
        {
            fileName = FName;
        }
        internal VehiclePosition Data
        {
            get
            {
                return data;
            }
        }

        internal bool CanRead
        {
            get
            {
                if(useCachedValues)
                {
                    return (!open || (position >= length));
                }
                else
                {
                    //return (!open || (fs.Position >= fs.Length));
                    return (!open || (br.BaseStream.Position >= br.BaseStream.Length));
                }

            }
        }

        internal void Open()
        {
            fs = new FileStream(fileName,FileMode.Open,FileAccess.Read,FileShare.Read);
            br = new BinaryReader(fs);
            length = fs.Length;
            position = 0;
            open = true;
        }

        internal bool Read()
        {
            if(!CanRead)
            {
                //data = VehiclePosition.FromBinaryReaderField(br);
                //data = VehiclePosition.FromFileStream(fs);
                data = VehiclePosition.FromBinaryReaderBlock(br);
                position += VPSize.Size;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
