using System.Diagnostics;
using AcTrainer.Trainer;

class Program
{
    static void main()
    {
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

        Trainer trainer = new(proc);

        while (true)
        {
            trainer.InfinityRiffleAmmo();
        }
    }
}
