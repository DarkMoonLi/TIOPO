using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Acer/Desktop/TIOPO/lab1/TestApp/tests.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string? line;

                StreamWriter writer = new StreamWriter("C:/Users/Acer/Desktop/TIOPO/lab1/TestApp/results.txt");
                while ((line = reader.ReadLine()) != null)
                {
                    var proc = new Process();
                    proc.StartInfo.FileName = "C:/Users/Acer/Desktop/TIOPO/lab1/lab1/bin/Debug/net5.0/lab1.exe";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;

                    string stringArgs = "";
                    var arguments = line.Split(' ');
                    foreach (string item in arguments)
                    {
                        if (double.TryParse(item, out double n) || item.Any(char.IsDigit))
                        {
                            stringArgs += item + ' ';
                        }
                    }
                    stringArgs = stringArgs.TrimEnd();
                    proc.StartInfo.Arguments = stringArgs;
                    proc.Start();
                    stringArgs = "";
                    foreach (string item in arguments)
                    {
                        if (!double.TryParse(item, out double n) && (!item.Any(char.IsDigit)))
                        {
                            stringArgs += item + ' ';
                        }
                    }

                    stringArgs = stringArgs.TrimEnd();

                    if (proc.StandardOutput.ReadLine() == stringArgs)
                    {
                        writer.WriteLine("success");
                    }
                    else
                    {
                        writer.WriteLine("error");
                    }
                    proc.WaitForExit();
                    proc.Close();
                }
                writer.Close();
            }
        }
    }
}
