using System;
using System.Diagnostics;
using System.IO;

namespace KeepMyDamAppRunning
{
    internal class Runcl
    {
        private System.Threading.Timer timer1;
        private readonly string appString;
        private readonly string processName;

        public Runcl(string appPath)
        {
            if (!System.IO.File.Exists(appPath))
            {
                timer1?.Dispose();
                throw new FileNotFoundException("Could not find file :{0}", appPath);
            }
            else
            {
                appString = appPath;

                processName = Path.GetFileNameWithoutExtension(appPath);
            }
        }

        public void Start()
        {
            timer1 = new System.Threading.Timer(e => RunApp(appString, processName), null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));
        }

        public void Stop()
        {
            timer1?.Dispose();
        }

        public static bool IsRunning(Process process)
        {
            try
            {
                Process.GetProcessById(process.Id);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }

        private void RunApp(string appPath, string processname)
        {
            //needs work for correct behaviour
            try
            {
                Process[] _p = Process.GetProcessesByName(processname);
                if (_p.Length > 0)
                {
                    if (IsRunning(Process.GetProcessesByName(processname)[0]))
                    {
                        return;
                        
                    }
                }
                else
                {
                    Process.Start(appPath);
                    Debug.Print("Process ran");
                   
                }
            }
            catch (IndexOutOfRangeException)
            {//not found in out process list start app
                Process.Start(appPath);
            }
        }
    }
}