using System;
using System.Threading;

namespace Pokemon
{
    class Program //Inicio del juego
    {
        static void Main(string[] args)
        {
            IO io = new IO();
            Game g = new Game();
            g.startGame();
            Console.ReadLine();
        }            
    }
}
