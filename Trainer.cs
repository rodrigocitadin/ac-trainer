using AcTrainer.Memory;
using System.Diagnostics;

namespace AcTrainer.Trainer;

public class Trainer
{
    Mem memory = new();
    IntPtr playerOffset = 0x17E0A8;
    IntPtr ammoOffset = 0x140;

    public void WriteAmmo()
    {
        Process proc;

        try
        {
            proc = Process.GetProcessesByName("ac_client")[0];
        }
        catch (Exception _err)
        {
            return;
        }

        IntPtr mainModuleBaseAddress = proc.MainModule.BaseAddress;

        IntPtr player = memory.readPointer(proc.Handle, mainModuleBaseAddress + playerOffset);
        IntPtr ammo = memory.readPointer(proc.Handle, player + ammoOffset);

        Console.WriteLine(ammo);
    }
}
