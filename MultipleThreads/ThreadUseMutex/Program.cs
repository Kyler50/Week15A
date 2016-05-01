using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadUseMutex
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            Mutex oneMutex = null;
            const string MutexName = "RUNMEONLYONCE";

            try 
            {
                oneMutex = Mutex.OpenExisting(MutexName);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
            }

            if (oneMutex == null)
            {
                oneMutex = new Mutex(true, MutexName);
            }
            else
            {
                oneMutex.Close();
                return;
            }

            Console.WriteLine("Our Application");
            Console.Read();
        }
    }

}
