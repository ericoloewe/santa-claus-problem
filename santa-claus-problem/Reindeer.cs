using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace santa_claus_problem
{
    class Reindeer
    {
        private static Random random = new Random();
        public int Index { get; private set; }
        internal Sleigh Sleigh { get; set; }

        public Reindeer(int index)
        {
            this.Index = index;
            StartLifeCycle();
            NorthPole.Events.OnCreateReindeer(Index);
        }

        internal void GoToVacationAndMeetSanta()
        {
            new Task(() =>
            {
                GoToVacation();
                MeetSanta();
            }).Start();
        }

        internal void OnUntie()
        {
            GoToVacationAndMeetSanta();
        }

        private void MeetSanta()
        {
            NorthPole.Events.OnReindeerMeetSanta(Index);
            NorthPole.SantaClausHouse.Meet(this);
        }

        private void GoToVacation()
        {
            NorthPole.Events.OnReindeerGoToVacation(Index);
            Thread.Sleep(NorthPole.MINIMAL_TIME_TO_WAIT * random.Next(0, 11));
        }
    }
}