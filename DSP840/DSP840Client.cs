using System.IO.Ports;
using System.Text;

namespace DSP840
{
    public class DSP840Client
    {
        private readonly SerialPort serialPort;
        public DSP840Client(string port)
        {
            serialPort = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public void Open() => serialPort.Open();
        public void Close() => serialPort.Close();
        public void Write(params byte[] data) => serialPort.Write(data, 0, data.Length);
        public void Write(string s) => serialPort.Write(s);

        public void PackageCommand(params byte[] cmd) => Write([0x04, 0x01, .. cmd, 0x17]);
        public void EscCommand(params byte[] cmd) => Write([0x1b, .. cmd]);
       
        public void SetUSA()
        {
            serialPort.Encoding = Encoding.ASCII;
            PackageCommand(0x49, 0x30);
        }

        public void SetRussia()
        {
            serialPort.Encoding = Encoding.GetEncoding(866);
            PackageCommand(0x49, 0x3C);
        }

        public void ClearScreen() => Write(0x0C);
        public void ClearCursorLine() => Write(0x18);
    }
}
