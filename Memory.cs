using System.Runtime.InteropServices;

namespace AcTrainer.Memory;

public class Mem
{
    [DllImport("kernel32.dll")]
    public static extern bool ReadProcessMemory(IntPtr process, IntPtr address, byte[] buffer, int size, ref int read);

    [DllImport("kernel32.dll")]
    public static extern bool WriteProcessMemory(IntPtr process, IntPtr address, byte[] buffer, int size, ref int write);
    
    int read, write;
    byte[] ptr = new byte[8];
    byte[] buffer = new byte[1024];

    public IntPtr readPointer(IntPtr proc, IntPtr address)
    {
        ReadProcessMemory(proc, address, buffer, 4, ref read);

        return (IntPtr)BitConverter.ToInt32(buffer, 0);
    }

    public byte[] readBytes(IntPtr proc, IntPtr address, int size)
    {
        ReadProcessMemory(proc, address, buffer, size, ref read);

        return buffer;
    }

    public void writeBytes(IntPtr proc, IntPtr address, byte[] newBytes)
    {
        WriteProcessMemory(proc, address, newBytes, newBytes.Length, ref write);
    }
}
