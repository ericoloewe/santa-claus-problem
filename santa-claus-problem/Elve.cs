using System;
using System.Threading;
using System.Threading.Tasks;

namespace santa_claus_problem
{
    class Elve
    {
        private static Random random = new Random(10);
        private int Index;

        public Elve(int index)
        {
            this.Index = index;
            StartLifeCycle();
            NorthPole.Events.OnCreateElve(Index);
        }

        public void RestartLifeCycle()
        {
            StartLifeCycle();
        }

        private void StartLifeCycle()
        {
            new Task(() =>
            {
                BuildToys();
                MeetSanta();
            });
        }

        private void BuildToys()
        {
            NorthPole.Events.OnElveBuildToys(Index);
            Thread.Sleep(NorthPole.MINIMAL_TIME_TO_WAIT * random.Next());
        }

        private void MeetSanta()
        {
            NorthPole.Events.OnElveMeetSanta(Index);
            NorthPole.SantaClausHouse.Meet(this);
        }
    }
}