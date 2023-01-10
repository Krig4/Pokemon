using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Pokemon
{
    class IO //Entrada y salida de texto
    {
        public static void SlowWrite(string s, int milisecond) // Escribir lento
        {
            for (int i = 0; i < s.Length; ++i)
            {
                Console.Write(s[i]);
                Thread.Sleep(milisecond);
            }
        }
        public static int intToString() // Leer número que introduce el usuario
        {
            int number = int.Parse(Console.ReadLine());
            return number;
        }
        public static string readLine() // Leer texto que introduce el usuario
        {
            string read = Console.ReadLine();
            return read;
        }
        public static char character() // Leer un caracter que introduce el usuario
        {
            char letter = Convert.ToChar(Console.ReadLine());
            return letter;
        }        
    }
}