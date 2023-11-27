using AcTrainer.Memory;
using System.Diagnostics;

namespace AcTrainer.Trainer;

public class Trainer
{
    Mem memory = new();

    IntPtr playerOffset = 0x17E0A8;
    IntPtr rifleAmmoOffset = 0x140;
    IntPtr healthOffset = 0xEC;
    IntPtr granadeOffset = 0x144;
    IntPtr armorOffset = 0xF0;

    public void InfinityRiffleAmmo(Process proc)
    {
        try
        {
            proc = Process.GetProcessesByName("ac_client")[0];
        }
        catch (Exception _ex)
        {
            return;
        }

        IntPtr mainModuleBaseAddress = proc.MainModule!.BaseAddress;

        IntPtr player = memory.readPointer(proc.Handle, mainModuleBaseAddress + playerOffset);
        IntPtr ammo = memory.readPointer(proc.Handle, player + rifleAmmoOffset);

        memory.writeBytes(proc.Handle, player + rifleAmmoOffset, BitConverter.GetBytes(20));
    }
}
