using System;
using santa_claus_problem;

namespace console
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthPole.GiveLiveToTheWorld(new NorthPoleEvents()
            {
                OnSantaClausSleep = () => Console.WriteLine("santa sleep"),
                OnSantaClausAwake = () => Console.WriteLine("santa awake")
            });
        }
    }
}
