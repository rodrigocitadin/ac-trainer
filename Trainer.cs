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
        IntPtr mainModuleBaseAddress = proc.MainModule!.BaseAddress;

        IntPtr player = memory.readPointer(proc.Handle, mainModuleBaseAddress + playerOffset);

        memory.writeBytes(proc.Handle, player + rifleAmmoOffset, BitConverter.GetBytes(20));
    }

    public void InfinityHealth(Process proc)
    {
        throw new NotImplementedException();
    }

    public void InfinityArmor(Process proc)
    {
        throw new NotImplementedException();
    }

    public void InfinityGranade(Process proc)
    {
        throw new NotImplementedException();
    }
}
