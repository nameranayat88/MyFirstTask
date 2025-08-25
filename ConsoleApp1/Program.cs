using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

class Native
{
    // DLL 1: MathFunc
    [DllImport("DLLMathLib.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern double Mult(double x, double y);

    // DLL 2: MathProj02 (string concat)
    [DllImport("DLLMathProj02.dll",
    EntryPoint = "MathFunc",                   // <- match the real name
    CallingConvention = CallingConvention.Cdecl,
    CharSet = CharSet.Unicode,
    ExactSpelling = true)]
    public static extern void MathDLL(string a, string b, StringBuilder outBuf, int outLen);


    // DLL 3: MathProj03
    [DllImport("DLLMathProj03.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int Divi(int m, int n);
}

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Happy Coding :)");

            // Call DLL #1
            double product = Native.Mult(45, 2);
            Console.WriteLine($"Mult result = {product}");

            // Call DLL #2
            var sb = new StringBuilder(256);
            Native.MathDLL("Hello ", "Welcome to DLL Universe, Mighty Coder!", sb, sb.Capacity);
            Console.WriteLine($"MathDLL result = {sb}");

            // Call DLL #3
            int divResult = Native.Divi(10, 2);
            Console.WriteLine($"Divi result = {divResult}");

            Console.ReadKey();
            Console.WriteLine($"BaseDir = {AppDomain.CurrentDomain.BaseDirectory}");
            Console.WriteLine($"Is64BitProcess = {Environment.Is64BitProcess}");

        }
    }
}
