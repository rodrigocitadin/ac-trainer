using AcTrainer.Memory;
using System.Diagnostics;

namespace AcTrainer.Trainer;

public class Trainer
{
    public Trainer(Process proc)
    {
        this.proc = proc;
    }

    Process proc;

    Mem memory = new();

    IntPtr playerOffset = 0x17E0A8;
    IntPtr rifleAmmoOffset = 0x140;
    IntPtr healthOffset = 0xEC;
    IntPtr granadeOffset = 0x144;
    IntPtr armorOffset = 0xF0;

    public void InfinityRiffleAmmo()
    {
        IntPtr mainModuleBaseAddress = proc.MainModule!.BaseAddress;

        IntPtr player = memory.readPointer(proc.Handle, mainModuleBaseAddress + playerOffset);

        memory.writeBytes(proc.Handle, player + rifleAmmoOffset, BitConverter.GetBytes(20));
    }

    public void InfinityHealth()
    {

        IntPtr mainModuleBaseAddress = proc.MainModule!.BaseAddress;

        IntPtr player = memory.readPointer(proc.Handle, mainModuleBaseAddress + playerOffset);

        memory.writeBytes(proc.Handle, player + healthOffset, BitConverter.GetBytes(100));
    }

    public void InfinityArmor()
    {
        IntPtr mainModuleBaseAddress = proc.MainModule!.BaseAddress;

        IntPtr player = memory.readPointer(proc.Handle, mainModuleBaseAddress + playerOffset);

        memory.writeBytes(proc.Handle, player + armorOffset, BitConverter.GetBytes(100));
    }

    public void InfinityGranade()
    {
        IntPtr mainModuleBaseAddress = proc.MainModule!.BaseAddress;

        IntPtr player = memory.readPointer(proc.Handle, mainModuleBaseAddress + playerOffset);

        memory.writeBytes(proc.Handle, player + granadeOffset, BitConverter.GetBytes(1));
    }
}
