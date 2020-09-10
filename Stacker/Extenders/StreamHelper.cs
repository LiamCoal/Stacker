using System.Collections.Generic;
using System.IO;

namespace Stacker.Extenders
{
    public static class StreamHelper
    {
        public static byte[] ReadBytes(this Stream stream, int count)
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < count; i++)
            {
                bytes.Add((byte) stream.ReadByte());
            }

            return bytes.ToArray();
        }

        public static byte[] ReadUntil(this Stream stream, byte b)
        {
            List<byte> bytes = new List<byte>();
            byte? current = null;
            while (current != b)
            {
                current = (byte?) stream.ReadByte();
                bytes.Add(current.Value);
            }
            bytes.RemoveAt(bytes.Count - 1);

            return bytes.ToArray();
        }
    }
}