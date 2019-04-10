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
                OnSantaClausAwake = () => Console.WriteLine("OnSantaClausAwake"),
                OnSantaClausSleep = () => Console.WriteLine("OnSantaClausSleep"),
                OnSantaDiscussToyProjects = () => Console.WriteLine("OnSantaDiscussToyProjects"),
                OnSantaGiveToys = () => Console.WriteLine("OnSantaGiveToys"),
                OnSantaTieReindeerGroup = () => Console.WriteLine("OnSantaTieReindeerGroup"),
                OnSantaUntieReindeerGroup = () => Console.WriteLine("OnSantaUntieReindeerGroup"),
                OnElvesAwakeSanta = i => Console.WriteLine($"OnElvesAwakeSanta-{i}"),
                OnCreateElve = i => Console.WriteLine($"OnCreateElve-{i}"),
                OnCreateReindeer = i => Console.WriteLine($"OnCreateReindeer-{i}"),
                OnElveBuildToys = i => Console.WriteLine($"OnElveBuildToys-{i}"),
                OnElveMeetSantaHouse = i => Console.WriteLine($"OnElveMeetSantaHouse-{i}"),
                OnReindeerGoToVacation = i => Console.WriteLine($"OnReindeerGoToVacation-{i}"),
                OnReindeerMeetSantaHouse = i => Console.WriteLine($"OnReindeerMeetSantaHouse-{i}"),
                OnReindeersAwakeSanta = i => Console.WriteLine($"OnReindeersAwakeSanta-{i}"),
            });
        }
    }
}
