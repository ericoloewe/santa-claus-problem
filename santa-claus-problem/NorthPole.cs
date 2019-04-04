using System;
using System.Collections.Generic;

namespace santa_claus_problem
{
    public class NorthPole
    {
        internal static int MINIMAL_TIME_TO_WAIT = 1000;
        internal static SantaClausHouse SantaClausHouse { get; private set; }
        internal static NorthPoleEvents Events { get; private set; }
        private static SantaClaus Santa { get; set; }
        private static Sleigh Sleigh { get; set; }
        private static IList<Reindeer> ReindeerGroup { get; set; } = new List<Reindeer>();
        private static IList<Elve> ElfeGroup { get; set; } = new List<Elve>();

        public static void GiveLiveToTheWorld(NorthPoleEvents events = null)
        {
            if (events == null)
            {
                events = new NorthPoleEvents();
            }

            Events = events;
            CreateReindersAndMeetSanta();
            CreateElvesAndMeetSanta();
            CreateSantaAndYourHouse();
        }

        private static void CreateSantaAndYourHouse()
        {
            Santa = new SantaClaus();
            Sleigh = new Sleigh();
            SantaClausHouse = new SantaClausHouse(Santa, Sleigh);
        }

        private static void CreateElvesAndMeetSanta()
        {
            for (int i = 0; i < 10; i++)
            {
                ElfeGroup.Add(new Elve(i));
            }
        }

        private static void CreateReindersAndMeetSanta()
        {
            for (int i = 0; i < 9; i++)
            {
                ReindeerGroup.Add(new Reindeer(i));
            }
        }
    }
}