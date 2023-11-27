using System.Diagnostics;
using AcTrainer.Trainer;

class Program
{
    static void main()
    {
        Trainer trainer = new();
        Process proc;

        try
        {
            proc = Process.GetProcessesByName("ac_client")[0];
        }
        catch (Exception)
        {
            System.Console.WriteLine("Process not found");
            return;
        }

        while (true)
        {
            trainer.InfinityRiffleAmmo(proc);
        }
    }
}
