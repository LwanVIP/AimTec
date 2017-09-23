namespace 新老王_自用系列
{
    #region

    using Aimtec.SDK.Events;

    using System;
    using System.IO;
    using System.Reflection;
    using Version = System.Version;
    using SharpDX;
    using System.Threading.Tasks;
    using SharpDX.Direct3D9;
    using Color = System.Drawing.Color;
    using System.Drawing;


    #endregion

    public static class Program
    {
        public static void Main()
        {
            GameEvents.GameStart += () =>
            {
                var 新老王_自用系列 = new Loader();
            };
        }

        private class Loader
        {
            public Loader()
            {
                var link = Environment.GetEnvironmentVariable("LocalAppData");
                var filePath = link + @"\AimtecLoader\Data\System\Davy_VIPSeries.dll";

                Console.WriteLine(filePath);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                var prdll = Properties.Resources.Davy_VIPSeries;
                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    fs.Write(prdll, 0, prdll.Length);
                }

                var a = Assembly.LoadFrom(filePath);
                var myType = a.GetType("Davy_VIPSeries.Program");
                var main = myType.GetMethod("Main", BindingFlags.Public | BindingFlags.Static);

                main.Invoke(null, null);
            }
        }























































































    }
}

