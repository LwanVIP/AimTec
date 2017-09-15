namespace 新老王_自用系列
{
    using Aimtec.SDK.Events;

    using System;
    using System.IO;
    using System.Reflection;

    internal class Program
    {
        private static readonly string getAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string dllPath = Path.Combine(getAppDataPath, @"Local\AimtecLoader\Data\System\Davy_VIPSeries.dll");

        private static void Main(string[] eventArgs)
        {
            GameEvents.GameStart += () =>
            {
                if (File.Exists(dllPath))
                {
                    File.Delete(dllPath);
                }

                //Add the Version check later

                var prdll = Properties.Resources.Davy_VIPSeries;
                using (var fs = new FileStream(dllPath, FileMode.Create))
                {
                    fs.Write(prdll, 0, prdll.Length);
                }

                var dllpath = Assembly.LoadFrom(dllPath);
                var main = dllpath.GetType("Davy_VIPSeries.Program").GetMethod("Main");
                main.Invoke(null, null);
            };
        }
    }
}