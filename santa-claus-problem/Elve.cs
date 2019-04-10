using System;
using System.Threading;
using System.Threading.Tasks;

namespace santa_claus_problem
{
    class Elve
    {
        private static Random random = new Random();
        public int Index { get; private set; }

        public Elve(int index)
        {
            this.Index = index;
            BuildToysAndMeetSanta();
            NorthPole.Events.OnCreateElve(Index);
        }

        internal void OnFinishToDiscussToyProject()
        {
            BuildToysAndMeetSanta();
        }

        private void BuildToysAndMeetSanta()
        {
            new Task(() =>
            {
                BuildToys();
                MeetSanta();
            }).Start();
        }

        private void BuildToys()
        {
            NorthPole.Events.OnElveBuildToys(Index);
            Thread.Sleep(NorthPole.MINIMAL_TIME_TO_WAIT * random.Next(0, 11));
        }

        private void MeetSanta()
        {
            NorthPole.Events.OnElveMeetSantaHouse(Index);
            NorthPole.SantaClausHouse.Meet(this);
        }
    }
}