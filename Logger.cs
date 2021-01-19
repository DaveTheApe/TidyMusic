using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TidyMusic
{
    public static class Logger
    {
        private static StringBuilder LogString = new StringBuilder();
        public static void Out(string str)
        {
            DateTime timestamp = DateTime.Now;
            Console.WriteLine(str);
            LogString.Append(timestamp).Append(str).Append(Environment.NewLine);
        }

        public static void SaveLog(string path="./tidyMusic.log")
        {
            StreamWriter file = System.IO.File.AppendText(path);
            file.Write(LogString.ToString());
            file.Close();
            file.Dispose();
        }

        public static void RotateLog(string path = "./tidyMusic.log")
        {
            if (File.Exists(path))
            {
                System.IO.File.Move(path, path + "_old");
            }
        }
    }
}
